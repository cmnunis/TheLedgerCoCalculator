# # The LedgerCo Calculator

The LedgerCo Calculator is a C# tool that returns data on repayments made by a borrower who has borrowed through the LedgerCo.

## Prerequisites
- Visual Studio 2019/2022
- .NET Core 5 or 6

## Setup
- Open the project in Visual Studio
- Copy the 2 `.txt` files that are found in the `Sample Input Files` folder to a directory of your choice i.e. `C:\Users\[username]\Documents`. 
- Open the `appsettings.json` file and change the `InputFileDirectory` file to the path where you have stored your files. 
- Run. 

## Validation
- For `Test File 1`, the following output is to be expected: 
```
IDIDI Dale 1000 55
IDIDI Dale 8000 20
MBI Harry 1044 12
MBI Harry 0 24
```

- For `Test File 2`:
```
IDIDI Dale 1326 9
IDIDI Dale 3652 4
UON Shelly 15856 3
MBI Harry 9044 10
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
