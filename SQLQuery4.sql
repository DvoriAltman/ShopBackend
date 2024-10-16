CREATE TABLE Users (
UserId INT PRIMARY KEY IDENTITY(1,1), -- מזהה ייחודי למשתמש, אוטומטי
UserName NVARCHAR(255) NOT NULL, -- שם המשתמש
Email NVARCHAR(255) NOT NULL UNIQUE, -- כתובת אימייל
Password NVARCHAR(255) NOT NULL, -- סיסמה
CreatedAt DATETIME DEFAULT GETDATE() -- תאריך יצירה );  
);
