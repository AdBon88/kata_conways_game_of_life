# Conway's Game of Life Kata  

The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970.  
The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input. One interacts with the Game of Life by creating an initial configuration and observing how it evolves.

## Rules of the game  
* The world is a 2D orthogonal grid of square cells
* Each cell has two states: living or dead
* Every cell has 8 neighbours. If the cells are at the boundary of the grid the neighbours laps over to the other side.

![Neighbours for non-boundary location](images/cell-neighbours-1.png)
![Neighbours for boundary location](images/cell-neighbours-boundary.png)

At each step in time (called a tick), the following transitions occur:  
* Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
* Any live cell with more than three live neighbours dies, as if by overcrowding.
* Any live cell with two or three live neighbours lives on to the next generation.
* Any dead cell with exactly three live neighbours becomes a live cell.  

![Game rules](images/rules.png)  

## Kata Tasks

The task is to implement Conway’s Game of Life which meets these requirements:  
* Visualize the game in the console
* Be able to define how big the world/grid is (10x10, 50x80, etc.)
* Be able to set the initial state of the world

## Getting Started

### System Requirements

* [.Net Core 3.1 SDK](https://dotnet.microsoft.com/download) or later  
* A command line interface (CLI) such as ```Command Prompt``` for Windows or ```Terminal``` for macOS

### Installation

1. Download the repository or clone to your computer using the ```git clone``` command
2. In the CLI, navigate into the folder containing the solution and enter ```dotnet restore``` to install the package dependencies
3. In the same folder, enter ```dotnet build``` to compile the projects

### Running the application
If using the CLI:
1. CD into the ```kata_conways_game_of_life``` project
2. Enter ```dotnet run Program.cs``` and press Enter to run

## How to use the application
1. Enter a whole number of at least 5 for the rows and press Enter. Repeat for and columns.
![Enter grid dimensions](images/app1.png)  
2. Enter a coordinate in the form x,y to specify a starting live cell location
![Enter grid dimensions](images/app2.png)  
3. Enter ```y``` to add another starting live cell location  
![Enter grid dimensions](images/app3.png)  
4. Repeat steps 2 and 3 until you no longer wish to add more starting live cell locations
5. Enter any key other than ```y``` to begin the game
6. The grid configuration will automatically update every second
7. Once all the cells are dead or no cells will change state at the next tick, the application will terminate.

## Running the tests

Using the CLI:
1. ```cd``` into the folder containing the solution file, or the ```kata_conways_game_of_life.tests```
2. Enter ```dotnet test``` and press Enter to run all the tests in the solution

### Cell Tests  
These tests checks that the state of a ```Cell``` object (dead or alive) is correct upon instantiation, death and revival.

### Location tests  
The location tests are used to check that each ```Location``` stores the correct state of the cell at the next tick (dead or alive). Per the game rules, each location's next cell state is dependent on how many surrounding live neighbours it has.

### Grid tests
The grid tests makes use of concrete ```Cell``` and ```Location``` objects to check that correct neighbours are used for each location to determine the next cell states.

### Game Tests  
The ```Game``` tests uses concrete ```Grid```, ```Location``` and ```Cell``` objects to test the interaction of these different classes together. The final grid display ```string``` is used to check that the game loop has been executed correctly and that the resultant grid configuration is correct when given a starting configuration. The starting configuration is obtained by using a Mock IInput object to specify the starting live locations. 

### Validator tests  
The ```Validator``` class methods returns a boolean to indicate if the input data is valid. The validator tests are used to verify that the validator methods' conditions are correct.  

### InputParser tests  
The ```InputParser``` class methods are used to parse input data from string to either integer or boolean data types if the given input is valid. The tests are used to check that the recursive methods in the ```InputParser``` are working correctly, whereby only valid data is parsed.

# Deployment
1. Enter ```dotnet publish``` in the CLI
2. To run the resultant application, enter ```kata_conways_game_of_life.dll```


## Built With

* [.Net Core 3.1](https://dotnet.microsoft.com/download) - The framework used
* [Nuget](https://www.nuget.org/) - Package Manager
* [XUnit](https://xunit.net/) - Testing framework
* [Moq](https://github.com/Moq/moq4/wiki/Quickstart) - Mocking framework
