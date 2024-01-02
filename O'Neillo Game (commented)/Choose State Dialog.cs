using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ONeilloGame.ONeilloGame;

namespace ONeilloGame
{
    public partial class ChooseStateDialog : Form
    {
        // Property to store the selected game state
        public ONeilloGameState SelectedGameState { get; private set; }

        // List to hold the game states
        private List<ONeilloGameState> gameStates;

        // Constructor for the ChooseStateDialog class
        public ChooseStateDialog(List<ONeilloGameState> gameStates)
        {
            InitializeComponent();
            this.gameStates = gameStates;

            // Populate the ListBox with the names of the saved game states
            UpdateListBox();
        }

        /// <summary>
        /// Updates the ListBox containing game states.
        /// </summary>
        public void UpdateListBox()
        {
            // Clear the ListBox before repopulating to avoid duplicates
            listBoxGameStates.Items.Clear();

            // Iterate through each game state and add information to the ListBox
            foreach (var gameState in gameStates)
            {
                // Include the current time in the game state name
                string currentTime = DateTime.Now.ToString("HH:mm");

                // Display relevant information about the game state in the ListBox
                listBoxGameStates.Items.Add($"Time ({currentTime}): Player 1: {gameState.Player1Name}, Player 2: {gameState.Player2Name}");
            }

            // Check if the number of stored states exceeds the limit (5)
            if (gameStates.Count > 5)
            {
                // Remove the oldest state to maintain the limit
                RemoveOldestGameState();
            }
        }

        /// <summary>
        /// Removes the oldest state if there are more than 5.
        /// </summary>
        private void RemoveOldestGameState()
        {
            // Check if there are states to remove
            if (listBoxGameStates.Items.Count > 0 && gameStates.Count > 0)
            {
                // Remove the oldest state from the ListBox
                listBoxGameStates.Items.RemoveAt(0);

                // Remove the oldest state from the list
                gameStates.RemoveAt(0);
            }
        }

        /// <summary>
        /// Sets the SelectedGameState property and closes the dialog.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox
            if (listBoxGameStates.SelectedItem != null)
            {
                // Set the SelectedGameState based on the selected item
                SelectedGameState = gameStates[listBoxGameStates.SelectedIndex];

                // Output information about the selected game state to the console
                if (SelectedGameState != null)
                {
                    Console.WriteLine($"Selected Game State: {SelectedGameState.Player1Name} vs {SelectedGameState.Player2Name}");
                }

                // Set DialogResult to OK and close the dialog
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Display a message to inform the user to select a game state
                MessageBox.Show("Please select a game state.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Closes the dialog with DialogResult.Cancel.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the dialog with DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Removes the selected game state from the ListBox and the list of game states.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox
            if (listBoxGameStates.SelectedItem != null)
            {
                // Get the selected game state name
                string selectedStateName = listBoxGameStates.SelectedItem.ToString();

                // Remove the selected item from the ListBox
                listBoxGameStates.Items.Remove(listBoxGameStates.SelectedItem);

                // Remove the corresponding game state from the list
                gameStates.RemoveAll(state => $"Player 1: {state.Player1Name}, Player 2: {state.Player2Name}" == selectedStateName);
            }
            else
            {
                // Display a message to inform the user to select a game state
                MessageBox.Show("Please select a game state to delete.", "Deletion Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
