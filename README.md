
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

Use the Package Manager Console in Visual Studio, select `DataAccessLayer` as `DefaultProject` and run
```cmd
Update-Database
```

Create file called `connection.env` in folder `Punishers/Application` with the following environmental variables
```env
SERVER=127.0.0.1
UID=<your-user>
PWD=<your-password>
DATABASE=AIBESTDB
```

Run the project

