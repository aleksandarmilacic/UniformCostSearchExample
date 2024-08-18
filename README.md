# Uniform Cost Search Example in C#

This project is a basic implementation of the Uniform Cost Search (UCS) algorithm in C#. It demonstrates how UCS can be used to find the least-cost path between nodes in a graph.

## Table of Contents

- [Introduction](#introduction)
- [How It Works](#how-it-works)
- [Setup](#setup)
- [Usage](#usage)
- [Output](#output)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Uniform Cost Search (UCS) is a search algorithm that finds the lowest-cost path from a start node to a goal node. It's particularly useful in situations where paths have different costs, and we want to ensure the path chosen is the most cost-effective.

This project provides a simple console application demonstrating UCS with a small graph of nodes.

## How It Works

- **Node Class:** Represents a point on the map, with neighbors and associated path costs.
- **UniformCostSearch Class:** Implements the UCS algorithm using a priority queue.
- **PriorityQueue Class:** A basic priority queue to manage nodes by their path costs.
- **Program Class:** Sets up the graph, runs the UCS algorithm, and outputs the results.

## Setup

To run this project, you need to have .NET 8 installed on your machine.

### Steps to Run

1. Clone the repository or download the project files.
2. Open your terminal and navigate to the project directory.
3. Run the following commands:

   ```bash
   dotnet build
   dotnet run
