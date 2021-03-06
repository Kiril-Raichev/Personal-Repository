# **Inventory Manager**
## **Objective**
### Your task is to implement a system that helps a store owner manage his inventory. New items can be added and filtered in the market. Here are the commands that the owner needs implement

### add {ITEM_NAME} {ITEM_PRICE} {ITEM_TYPE} � adds a new item to the system;
* ### ITEM_NAME is a character sequence and has to be unique;
* ### ITEM_PRICE is a positive floating-point number;
* ### ITEM_TYPE is a character sequence and does not have to be unique;
	* ### If the item is added successfully, print: Ok: Item {ITEM_NAME} added successfully;
	* ###	If an item with the given name already exists, print: Error: Item {ITEM_NAME} already exists;
### filter by type {ITEM_TYPE} � lists the first 10 items (sorted) that have type equal to ITEM_TYPE;
* ### If the given ITEM_TYPE does not exist, print: Error: Type {ITEM_TYPE} does not exist;
### filter by price from {MIN_PRICE} to {MAX_PRICE} � lists the first 10 (sorted) items that have ITEM_PRICE in the given range, inclusive;
### filter by price from {MIN_PRICE} � lists the first 10 items (sorted) that have a greater ITEM_PRICE than the given, inclusive;
### filter by price to {MAX_PRICE} � lists the first 10 items (sorted) that have a smaller ITEM_PRICE that the given, inclusive;
### end � marks the end of the commands. No commands will follow.
### All items that are listed by the filter commands must be printed in the following format:

* ###	Ok: {LIST_OF_ITEMS}
### LIST_OF_ITEMS contains the filtered items, separated by a space and a comma (", ") and each item is represented as ITEM_NAME(ITEM_PRICE). The list should be 10 or less products. The price is formatted up two decimal places. They must also be sorted by the following criteria:

* ### First by ITEM_PRICE, ascending
* ### Then by ITEM_NAME, ascending
* ### Lastly by ITEM_TYPE, ascending
### If LIST_OF_ITEMS contains no items, then print just:

* ### Ok: 
## <b>Input</b>
### The input data is given at the standard input. It consists of a sequence of commands, each at a separate line, ending by the command end. The commands will be valid (as described in the above list), in the specified format, within the constraints given below. There is no need to check the input data explicitly.

## **Output**
### For each command from the input sequence print at the standard output its result on a single line.

## Constraints
### All ITEM_NAME and ITEM_TYPE will consist of letters and digits only. No spaces are allowed.
### The total number of lines in the input will be in the range [1 � 50 000]
