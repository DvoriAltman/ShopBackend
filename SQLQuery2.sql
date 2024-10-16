CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1), -- מזהה ייחודי למוצר, אוטומטי
    ProductName NVARCHAR(255) NOT NULL, -- שם המוצר
    CategoryId INT NOT NULL, -- מזהה הקטגוריה
    Price DECIMAL(18, 2) NOT NULL, -- מחיר המוצר
    ImagePath NVARCHAR(255) -- נתיב התמונה
);
