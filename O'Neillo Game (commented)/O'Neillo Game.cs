using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Speech.Synthesis;
using Newtonsoft.Json; // Imported the Newtonsoft.Json library for JSON serialization

namespace ONeilloGame
{
    public partial class ONeilloGame : Form
    {
        // Boolean flag indicating the current player's turn
        bool turn = true;

        // Constants and variables for board dimensions and disk counts
        int cellSize = 50, xOffset = 60, yOffset = 60, yOffsetAbove = 60, xOffsetLeft = 30;
        int blackCount = 0, whiteCount = 0;

        // Variables to store the last clicked disk's position
        int lastClickedRow = -1, lastClickedCol = -1;

        // Flag to control the visibility of the information panel
        private bool informationPanelVisible = true;

        // Speech synthesis for text-to-speech functionality
        private SpeechSynthesizer synthesizer;

        // 2D array to represent the game board as a grid of panels (disks)
        Panel[,] disks = new Panel[8, 8];

        // List to store game states for saving and loading
        private List<ONeilloGameState> gameStates = new List<ONeilloGameState>();

        // Instance of ChooseStateDialog for managing saved game states
        private ChooseStateDialog chooseStateDialog; // Added this line

        public ONeilloGame()
        {
            // Initialize components, set up the game board, and highlight available moves
            InitializeComponent();
            InitialiseBoard();
            HighlightAvailableMoves();

            // Initialize the SpeechSynthesizer for text-to-speech functionality
            synthesizer = new SpeechSynthesizer();

            // Initialize the instance of ChooseStateDialog, passing the list of game states
            chooseStateDialog = new ChooseStateDialog(gameStates);

            // Populate the ListBox in the ChooseStateDialog instance
            chooseStateDialog.UpdateListBox();
        }


        /// <summary>
        /// Represents the state of the O'Neillo game.
        /// </summary>
        [Serializable]
        public class ONeilloGameState
        {
            /// <summary>
            /// Gets or sets the game board represented as a 2D array.
            /// </summary>
            public int[,] Board { get; set; }

            /// <summary>
            /// Gets or sets the name of Player 1.
            /// </summary>
            public string Player1Name { get; set; }

            /// <summary>
            /// Gets or sets the name of Player 2.
            /// </summary>
            public string Player2Name { get; set; }

            /// <summary>
            /// Gets or sets the count of black disks on the board.
            /// </summary>
            public int BlackCount { get; set; }

            /// <summary>
            /// Gets or sets the count of white disks on the board.
            /// </summary>
            public int WhiteCount { get; set; }

            /// <summary>
            /// Constructor for initializing the ONeilloGameState with specific parameters.
            /// </summary>
            /// <param name="board">The initial state of the game board.</param>
            /// <param name="player1">The name of Player 1.</param>
            /// <param name="player2">The name of Player 2.</param>
            /// <param name="blackCount">The count of black disks on the board.</param>
            /// <param name="whiteCount">The count of white disks on the board.</param>
            public ONeilloGameState(int[,] board, string player1, string player2, int blackCount, int whiteCount)
            {
                Board = board;
                Player1Name = player1;
                Player2Name = player2;
                BlackCount = blackCount;
                WhiteCount = whiteCount;
            }
        }

        /// <summary>
        /// Initializes the O'Neillo game board and sets up the disks.
        /// </summary>
        private void InitialiseBoard()
        {
            // Loop through rows and columns to create disks
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Calculate the position of the disk
                    int x = col * xOffset + xOffsetLeft;
                    int y = yOffsetAbove + row * yOffset;

                    // Create a circular-shaped panel as a disk
                    Panel board = new Panel
                    {
                        Location = new Point(x, y),
                        Size = new Size(cellSize, cellSize),
                    };

                    // Set the region of the panel to create a circular shape
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0, 0, board.Width, board.Height);
                    board.Region = new Region(path);

                    board.BackColor = Color.Green; // Set the default background color to green

                    // Place default black and white disks in the center
                    if ((row == 3 || row == 4) && (col == 3 || col == 4))
                    {
                        board.BackColor = (row + col) % 2 == 0 ? Color.White : Color.Black;
                        if (board.BackColor == Color.Black)
                            blackCount++;
                        else
                            whiteCount++;
                    }

                    board.Click += WhenDiskPlaced; // Subscribe to the click event

                    Controls.Add(board); // Add the disk to the form
                    disks[row, col] = board; // Store a reference to the disk
                }

                pbToPlayWhite.Visible = false; // Hide the white player's indicator initially
            }

            lblBlackCounter.Text = blackCount.ToString();
            lblWhiteCounter.Text = whiteCount.ToString();
        }

        /// <summary>
        /// Handles the click event for a disk.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void WhenDiskPlaced(object sender, EventArgs e)
        {
            // Get the clicked disk from the sender
            Panel DiskClicked = (Panel)sender;

            // Find the clicked disk in the 2D array
            int clickedRow = -1;
            int clickedCol = -1;

            // Iterate through the array to find the clicked disk's coordinates
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (disks[row, col] == DiskClicked)
                    {
                        clickedRow = row;
                        clickedCol = col;
                        break;
                    }
                }
            }

            // Check if the clicked disk is valid and a legal move
            if (clickedRow != -1 && clickedCol != -1 && ValidateDiskPlaced(clickedRow, clickedCol))
            {
                // Update the color of the clicked disk based on the current player's turn
                if (turn)
                {
                    DiskClicked.BackColor = Color.Black; // Place a black disk
                }
                else
                {
                    DiskClicked.BackColor = Color.White; // Place a white disk
                }

                // Call FlipDisks method to flip the appropriate disks
                FlipDisks(clickedRow, clickedCol);

                // Toggle the turn after a valid move
                turn = !turn;

                // Update the count labels based on the current board state
                UpdateDiskCounters();

                // Update the player turn indicators (e.g., displaying player names or symbols)
                UpdatePlayerTurnIndicators();

                // Store the last clicked disk's coordinates for speech synthesis
                UpdateLastClickedDisk(clickedRow, clickedCol);

                // Highlight valid moves for the next player
                HighlightAvailableMoves();

                // Check if text-to-speech is enabled
                if (!speakToolStripMenuItem.Checked)
                {
                    // Cancel any ongoing speech
                    synthesizer.SpeakAsyncCancelAll();
                }
                else
                {
                    // Speak the current player's turn and the latest move
                    SpeakToolStripMenuItem_Click(null, EventArgs.Empty);
                }

                // If the current player has no valid moves, switch to the other player
                if (!CheckForValidMoves())
                {
                    turn = !turn;
                    // Highlight valid moves for the other player
                    HighlightAvailableMoves();
                }

                // Check if the game is over and display the winner
                if (!CheckForValidMoves())
                {
                    CheckGameOver();
                    string winner = GetWinner();
                    MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Checks if the current player has a valid move on the board.
        /// </summary>
        /// <returns>True if there is at least one valid move; otherwise, false.</returns>
        private bool CheckForValidMoves()
        {
            // Iterate through all disks on the board to check for a valid move
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (ValidateDiskPlaced(row, col))
                    {
                        return true; // Return true if a valid move is found
                    }
                }
            }
            return false; // Return false if no valid move is found
        }

        /// <summary>
        /// Highlights valid moves on the game board with a grey background.
        /// </summary>
        private void HighlightAvailableMoves()
        {
            // Iterate through all disks on the game board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Panel currentDisk = disks[row, col];

                    // Check if the disk is a valid move
                    if (ValidateDiskPlaced(row, col))
                    {
                        // Highlight the valid move with a grey background
                        currentDisk.BackColor = Color.Gray;
                    }
                    // Check if the disk was previously highlighted as a valid move
                    else if (currentDisk.BackColor == Color.Gray)
                    {
                        // Reset the background color to the default for non-occupied grey disks
                        currentDisk.BackColor = Color.Green;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a disk is a valid move based on Othello rules.
        /// </summary>
        /// <param name="row">The row index of the disk.</param>
        /// <param name="col">The column index of the disk.</param>
        /// <returns>True if the move is valid, false otherwise.</returns>
        private bool ValidateDiskPlaced(int row, int col)
        {
            // Check if the disk is already occupied
            if (disks[row, col].BackColor == Color.Black || disks[row, col].BackColor == Color.White)
            {
                return false;
            }

            // Arrays to represent the eight possible directions to check
            int[] dr = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] dc = { -1, 0, 1, 1, 1, 0, -1, -1 };

            bool validMove = false;

            // Iterate through all directions
            for (int direction = 0; direction < 8; direction++)
            {
                int r = row + dr[direction];
                int c = col + dc[direction];
                bool foundOpponent = false;

                // Check disks in the current direction
                while (r >= 0 && r < 8 && c >= 0 && c < 8)
                {
                    // Check if the disk belongs to the opponent
                    if (disks[r, c].BackColor == (turn ? Color.White : Color.Black))
                    {
                        foundOpponent = true;
                    }
                    // Check if the disk belongs to the current player and an opponent disk was found
                    else if (disks[r, c].BackColor == (turn ? Color.Black : Color.White) && foundOpponent)
                    {
                        validMove = true; // At least one valid direction is found
                        break; // No need to check other directions
                    }
                    // If the disk is empty, break the loop
                    else
                    {
                        break;
                    }

                    r += dr[direction];
                    c += dc[direction];
                }
            }

            return validMove;
        }

        /// <summary>
        /// Flips disks in all directions based on the current move.
        /// </summary>
        /// <param name="row">The row index of the disk.</param>
        /// <param name="col">The column index of the disk.</param>
        private void FlipDisks(int row, int col)
        {
            // Arrays to represent the eight possible directions to check
            int[] dr = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] dc = { -1, 0, 1, 1, 1, 0, -1, -1 };

            // Iterate through all directions
            for (int direction = 0; direction < 8; direction++)
            {
                int r = row + dr[direction];
                int c = col + dc[direction];
                bool foundOpponent = false;

                // Check disks in the current direction
                while (r >= 0 && r < 8 && c >= 0 && c < 8)
                {
                    // Check if the disk belongs to the opponent
                    if (disks[r, c].BackColor == (turn ? Color.White : Color.Black))
                    {
                        foundOpponent = true;
                    }
                    // Check if the disk belongs to the current player and an opponent disk was found
                    else if (disks[r, c].BackColor == (turn ? Color.Black : Color.White) && foundOpponent)
                    {
                        // Flip the disks in this direction
                        FlipDisksInDirection(row, col, r, c, direction);
                        break;
                    }
                    // If the disk is empty, break the loop
                    else
                    {
                        break;
                    }

                    r += dr[direction];
                    c += dc[direction];
                }
            }
        }

        /// <summary>
        /// Flips disks in a specific direction based on the current move.
        /// </summary>
        /// <param name="startRow">The starting row index of the move.</param>
        /// <param name="startCol">The starting column index of the move.</param>
        /// <param name="endRow">The ending row index of the move.</param>
        /// <param name="endCol">The ending column index of the move.</param>
        /// <param name="direction">The direction in which disks need to be flipped.</param>
        private void FlipDisksInDirection(int startRow, int startCol, int endRow, int endCol, int direction)
        {
            Console.WriteLine("FlipDisksInDirection called"); // Debugging line

            // Arrays to represent the eight possible directions to check
            int[] dr = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] dc = { -1, 0, 1, 1, 1, 0, -1, -1 };

            int r = startRow + dr[direction];
            int c = startCol + dc[direction];

            // Iterate through the disks in the specified direction and flip them
            while (r != endRow || c != endCol)
            {
                disks[r, c].BackColor = turn ? Color.Black : Color.White;
                r += dr[direction];
                c += dc[direction];
            }
        }

        /// <summary>
        /// Checks if the game is over by examining the total count of black and white disks.
        /// </summary>
        /// <returns>True if the game is over, false otherwise.</returns>
        private bool CheckGameOver()
        {
            // Check if the total count of black and white disks equals the total number of disks on the board (64)
            return blackCount + whiteCount == 64;
        }

        /// <summary>
        /// Determines the winner of the game based on the counts of black and white disks.
        /// </summary>
        /// <returns>The winner's name or a tie message.</returns>
        private string GetWinner()
        {
            // Get the names from the textboxes or use default names
            string player1Name = string.IsNullOrEmpty(txtPlayer1.Text) ? "Player 1" : txtPlayer1.Text;
            string player2Name = string.IsNullOrEmpty(txtPlayer2.Text) ? "Player 2" : txtPlayer2.Text;

            // Compare the counts of black and white disks to determine the winner or declare a tie
            if (blackCount > whiteCount)
                return player1Name; // Return the name from the txtPlayer1 TextBox
            else if (whiteCount > blackCount)
                return player2Name; // Return the name from the txtPlayer2 TextBox
            else
                return "It's a tie";
        }

        /// <summary>
        /// Updates the counters and labels based on the current state of the game board.
        /// </summary>
        private void UpdateDiskCounters()
        {
            int black = 0;
            int white = 0;

            // Iterate through all disks on the board to count black and white disks
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (disks[row, col].BackColor == Color.Black)
                    {
                        black++;
                    }
                    else if (disks[row, col].BackColor == Color.White)
                    {
                        white++;
                    }
                }
            }

            // Update the global counts
            blackCount = black;
            whiteCount = white;

            // Update the labels displaying the counts
            lblBlackCounter.Text = blackCount.ToString();
            lblWhiteCounter.Text = whiteCount.ToString();
        }

        /// <summary>
        /// Updates the indicators to display the current player's turn.
        /// </summary>
        private void UpdatePlayerTurnIndicators()
        {
            // Check the current turn and update the visibility of the indicators accordingly
            if (turn)
            {
                pbToPlayBlack.Visible = true;
                pbToPlayWhite.Visible = false;
            }
            else
            {
                pbToPlayBlack.Visible = false;
                pbToPlayWhite.Visible = true;
            }
        }

        /// <summary>
        /// Gets the coordinates of the latest disk placed on the board.
        /// </summary>
        /// <returns>The coordinates in the format "A, 1" to "H, 8" or null if no disk has been placed yet.</returns>
        private string GetLatestDiskCoordinates()
        {
            // Check if a disk has been clicked
            if (lastClickedRow != -1 && lastClickedCol != -1)
            {
                // Convert the column index to the corresponding letter (A to H)
                char columnLetter = (char)('A' + lastClickedCol);
                // Convert the row index to match 1-8
                int rowNumber = lastClickedRow + 1;

                // Format and return the coordinates
                string coordinates = $"{columnLetter}, {rowNumber}";
                return coordinates;
            }

            // Return null if no disk has been placed yet
            return null;
        }

        /// <summary>
        /// Updates the position of the last clicked disk.
        /// </summary>
        /// <param name="clickedRow">The row index of the clicked disk.</param>
        /// <param name="clickedCol">The column index of the clicked disk.</param>
        private void UpdateLastClickedDisk(int clickedRow, int clickedCol)
        {
            // Update the global variables to store the position of the last clicked disk
            lastClickedRow = clickedRow;
            lastClickedCol = clickedCol;
        }

        /// <summary>
        /// Exits the application when the menu item is clicked.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Prompts the user to save the current game state, restarts the game, or cancels based on user input.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastClickedRow != -1)
            {
                // Prompt the user to save the current game state
                DialogResult result = MessageBox.Show("Do you want to save the current game state?",
                                                      "Save Game",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveGame();
                }
                else if (result == DialogResult.Cancel)
                {
                    // If the user clicks Cancel, do not restart the game
                    return;
                }
            }

            // Restart the game
            Application.Restart();
        }

        /// <summary>
        /// Saves the current game state, providing options to overwrite an existing state or save as a new one.
        /// </summary>
        private void SaveGame()
        {
            try
            {
                // If there are existing game states, ask the user if they want to overwrite or create a new one
                if (gameStates.Count > 0)
                {
                    var overwriteDialogResult = MessageBox.Show("Do you want to overwrite an existing game state?",
                                                                "Overwrite Existing State",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question);

                    if (overwriteDialogResult == DialogResult.Yes)
                    {
                        // Show the dialog to choose the state to overwrite
                        using (ChooseStateDialog overwriteDialog = new ChooseStateDialog(gameStates))
                        {
                            DialogResult result = overwriteDialog.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                // Overwrite the selected game state
                                OverwriteGameState(overwriteDialog.SelectedGameState, GetBoardState());
                            }
                        }
                    }
                    else
                    {
                        // Save the current state as a new one
                        SaveAsNewGame();
                    }
                }
                else
                {
                    // Save the current state as a new one if there are no existing game states
                    SaveAsNewGame();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the current game state as a new entry in the list of game states.
        /// </summary>
        private void SaveAsNewGame()
        {
            try
            {
                // Create a data structure to store the game state
                var gameState = new ONeilloGameState(
                    GetBoardState(),  // Assuming GetBoardState() returns int[,]
                    txtPlayer1.Text,
                    txtPlayer2.Text,
                    blackCount,
                    whiteCount
                );

                // Add the new game state to the list
                gameStates.Add(gameState);

                // Save the updated list of game states
                SaveGameStatesToFile();

                // Update the ListBox in the ChooseStateDialog
                chooseStateDialog.UpdateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game as a new state: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Overwrites the provided game state with a new board state and updates other properties as needed.
        /// </summary>
        /// <param name="gameStateToOverwrite">The game state to overwrite.</param>
        /// <param name="newBoardState">The new board state.</param>
        private void OverwriteGameState(ONeilloGameState gameStateToOverwrite, int[,] newBoardState)
        {
            try
            {
                // Check for null reference
                if (gameStateToOverwrite != null)
                {
                    // Update the game state with the new board state
                    gameStateToOverwrite.Board = newBoardState;

                    // Update any other properties as needed

                    // Save the updated list of game states
                    SaveGameStatesToFile();

                    // Update the ListBox in the ChooseStateDialog
                    chooseStateDialog.UpdateListBox();
                }
                else
                {
                    // Handle the case where gameStateToOverwrite is null (e.g., log an error or show a message)
                    MessageBox.Show("Error: gameStateToOverwrite is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error overwriting game state: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the current list of game states to a JSON file.
        /// </summary>
        private void SaveGameStatesToFile()
        {
            try
            {
                if (gameStates != null)
                {
                    // Convert the list of game states to JSON format
                    string json = JsonConvert.SerializeObject(gameStates);

                    // Write the JSON data to a file named "game_data.json"
                    File.WriteAllText("game_data.json", json);
                }
                else
                {
                    // Handle the case where gameStates is null (e.g., log an error or show a message)
                    MessageBox.Show("Error: gameStates is null");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game states to file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the "Load Game" menu item click event.
        /// </summary>
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the list of existing game states
                List<ONeilloGameState> existingGameStates = LoadGameStates();

                // Display a dialog to let the user choose which state to load
                ChooseStateDialog dialog = new ChooseStateDialog(existingGameStates);
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Load the selected game state
                    LoadGameState(dialog.SelectedGameState);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the game states from the "game_data.json" file.
        /// </summary>
        /// <returns>The list of loaded game states.</returns>
        private List<ONeilloGameState> LoadGameStates()
        {
            List<ONeilloGameState> gameStates = new List<ONeilloGameState>();

            try
            {
                string json = File.ReadAllText("game_data.json");
                gameStates = JsonConvert.DeserializeObject<List<ONeilloGameState>>(json);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game states: {ex.Message}");
            }

            return gameStates;
        }

        /// <summary>
        /// Loads the provided game state and updates the game board and player names accordingly.
        /// </summary>
        /// <param name="gameState">The game state to load.</param>
        private void LoadGameState(ONeilloGameState gameState)
        {
            if (gameState != null)
            {
                // Update the board with the loaded state
                UpdateBoardFromGameState(gameState);

                // Update player names
                txtPlayer1.Text = gameState.Player1Name;
                txtPlayer2.Text = gameState.Player2Name;

                // Highlight available moves after loading the game state
                HighlightAvailableMoves();
            }
        }

        /// <summary>
        /// Retrieves the current state of the game board and represents it as a 2D integer array.
        /// </summary>
        /// <returns>A 2D integer array representing the current state of the game board.</returns>
        private int[,] GetBoardState()
        {
            int[,] boardState = new int[8, 8];

            // Iterate through the disks to save their positions
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Use 1 to represent a black disk, 2 to represent a white disk, and 0 for an empty position
                    if (disks[row, col].BackColor == Color.Black)
                    {
                        boardState[row, col] = 1;
                    }
                    else if (disks[row, col].BackColor == Color.White)
                    {
                        boardState[row, col] = 2;
                    }
                    else
                    {
                        boardState[row, col] = 0;
                    }
                }
            }

            return boardState;
        }

        /// <summary>
        /// Handles the "Save Game" menu item click event.
        /// </summary>
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastClickedRow != -1)
            {
                // Prompt the user to save the current game state
                DialogResult result = MessageBox.Show("Do you want to save the current game state?",
                                                      "Save Game",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveGame();
                }
                else if (result == DialogResult.Cancel)
                {
                    // If the user clicks Cancel, do not save the game
                    return;
                }
            }

            SaveGame();
        }

        /// <summary>
        /// Updates the game board based on the provided game state.
        /// </summary>
        /// <param name="gameState">The game state containing the board configuration.</param>
        private void UpdateBoardFromGameState(ONeilloGameState gameState)
        {
            // Iterate through the board and update the disk colors
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Use 1 to represent a black disk, 2 to represent a white disk
                    if (gameState.Board[row, col] == 1)
                    {
                        disks[row, col].BackColor = Color.Black;
                    }
                    else if (gameState.Board[row, col] == 2)
                    {
                        disks[row, col].BackColor = Color.White;
                    }
                    else
                    {
                        disks[row, col].BackColor = Color.Green; // Update to the default color if it's not a disk
                    }
                }
            }
        }

        /// <summary>
        /// Toggles the visibility of the information panel and associated controls.
        /// </summary>
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            informationPanelVisible = !informationPanelVisible; // Toggle the visibility flag

            bool controlsVisible = informationPanelVisible;

            // Update the visibility of the picture boxes based on the flag
            if (informationPanelVisible)
            {
                pbToPlayBlack.Visible = turn; // Show the black player's turn indicator when the information panel is visible
                pbToPlayWhite.Visible = !turn; // Show the white player's turn indicator when the information panel is visible
            }
            else
            {
                pbToPlayBlack.Visible = false; // Hide the black player's turn indicator when the information panel is hidden
                pbToPlayWhite.Visible = false; // Hide the white player's turn indicator when the information panel is hidden
            }

            // Update the visibility of other controls based on the flag
            txtPlayer1.Visible = controlsVisible;
            txtPlayer2.Visible = controlsVisible;
            lblBlackCounter.Visible = controlsVisible;
            lblWhiteCounter.Visible = controlsVisible;
            lblBlackCount.Visible = controlsVisible;
            lblWhiteCount.Visible = controlsVisible;
        }

        /// <summary>
        /// Toggles speech usability setting.
        /// </summary>
        private void SpeakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string playerName = turn ? txtPlayer1.Text : txtPlayer2.Text;
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = turn ? "Player 1" : "Player 2"; // Use default names if text boxes are empty
            }

            string playerNameWithS = $"{playerName}'s"; // Adds an 's' to end of players names

            string latestMove = GetLatestDiskCoordinates(); // Gets the latest move

            if (!string.IsNullOrEmpty(latestMove))
            {
                string textToSpeak = $"{playerNameWithS} turn. Latest move at {latestMove}"; // Reads outloud the players name and latest move
                synthesizer.SpeakAsync(textToSpeak);
            }
        }

        /// <summary>
        /// Opens the Help Modal.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the HelpModal form
            HelpModal helpModal = new HelpModal();

            // Display the HelpModal form as a modal dialog, it blocks the main application until closed
            helpModal.ShowDialog();
        }

    }
}
