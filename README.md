
# Punishers




## Run Locally

Clone the project

```bash
  git clone https://github.com/KKDinev20/Punishers.git
```

Go to the project directory

```bash
  cd Punishers
```

Run the MySQL script in `DB/` folder

Use the Package Manager Console in Visual Studio, select `DataAccessLayer` as `DefaultProject` and run to migrate database to latest migration
```cmd
Update-Database
```

Create file called `connection.env` in folder `Punishers/Application` with the following environmental variables
```env
SERVER=127.0.0.1
UID=AIBESTUser
PWD=DevPass
DATABASE=AIBESTDB
```

Run the project

Note:

If you want to create or modify records in the database using MySQL Workbench create the needed connection. Useful information found [here](https://dev.mysql.com/doc/workbench/en/wb-mysql-connections.html) 
