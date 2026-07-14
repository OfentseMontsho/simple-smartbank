# simple-smartbank

### ABOUT:

A sleek, meticulous command-line banking interface built to provide a structured, interactive way to handle simulated financial accounts. This application showcases core object-oriented principles, asynchronous flow mimicry, and robust user-input validation in C#.

---

### FEATURES & SYSTEM LOGIC:

1. **Robust Input Validation (`CorrectInt`):** Prevents run-time exceptions by catching invalid numeric characters or negative monetary values using safe `double.TryParse` filtering loops.
2. **Transaction Tracking Architecture:** Leverages a custom dynamic `List<TransactionHistory>` structure that instantiates object timestamps every time money changes hands.
3. **Fail-Safe Withdrawal Logic:** Evaluates account balance thresholds prior to deduction to prevent balances from dropping into negative limits.
4. **Clean Color-Coded Interfaces:** Employs explicit Windows console system colors to visually segment headers, logs, and critical menus for optimized user navigation.

---

### CORE TECHNOLOGIES USED:

* **C# / .NET:** The foundational architecture handling data storage, object properties, and programmatic control flow.
* **Visual Studio:** The IDE utilized for compiling code, tracking memory dependencies, and debugging console inputs.

---

### GETTING STARTED & LOCAL INSTALLATION:

To run this application locally on your computer, follow these straightforward steps:

1. **Clone the repository:**
2. Open the project's folder and double-click the `.sln` (Solution) file to boot it up inside **Visual Studio**.
3. Press `F5` or click the **Start / Run** button at the top of your screen.
4. Press any key to interactively advance through the custom dashboard menus!
