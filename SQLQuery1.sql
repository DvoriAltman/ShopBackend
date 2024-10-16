
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,  -- מזהה הזמנה, אוטומטי ומפתח ראשי
    UserId INT NOT NULL,                   -- מזהה משתמש
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(), -- תאריך הזמנה, ברירת מחדל היא תאריך ושעה נוכחיים
    TotalAmount DECIMAL(18, 2) NOT NULL,  -- סכום כולל, מספר עם 2 ספרות אחרי הנקודה
    PaymentStatus VARCHAR(50) NOT NULL,    -- סטטוס תשלום, ניתן לשנות את האורך לפי הצורך
);
