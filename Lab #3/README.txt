# Blackjack Windows Forms Game

This is a basic Windows Forms Blackjack game built in C#.

## Features
- Player starts with **$100** balance
- Bet an amount each round
- Draw cards with **Deal** and **Hit** buttons
- End turn with **Stay** button
- Dealer plays automatically
- Shows **all cards**, winner, and updates balance
- Tracks **game history** (bet, cards, result, balance)
- View history in a separate **History** window

## 🛠 Technologies
- C#
- .NET Windows Forms

## 📂 Files
- `GameForm.cs` – Main game logic and UI
- `Deck.cs` / `Card.cs` – Card drawing and deck management
- `GameResult.cs` – Stores results for history
- `HistoryForm.cs` – Shows game history in a DataGridView
