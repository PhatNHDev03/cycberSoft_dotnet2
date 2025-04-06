use dotnet_session37
-- index
-- có 2 loại đánh index 
-- clustered index (primary key)


-- unclustered  index 

create table products(
	id int primary key Identity (1,1),
	name nvarchar(100),
	price decimal (10,2),
	category nvarchar(50)
)


--- proc
SET NOCOUNT ON;
DECLARE @i INT = 0;

WHILE @i < 5000
BEGIN
    INSERT INTO products (name, price, category)
    VALUES (
        N'Product ' + CAST(@i AS NVARCHAR(10)), -- Tạo tên sản phẩm ngẫu nhiên
        ROUND(RAND() * (1000 - 10) + 10, 2), -- Giá ngẫu nhiên từ 10 đến 1000
        CASE ABS(CHECKSUM(NEWID())) % 5 -- 5 danh mục ngẫu nhiên
            WHEN 0 THEN N'Electronics'
            WHEN 1 THEN N'Clothing'
            WHEN 2 THEN N'Home & Kitchen'
            WHEN 3 THEN N'Sports'
            ELSE N'Books'
        END
    );

    SET @i = @i + 1;
END;


SELECT TOP 100 *  FROM products
-- đánh index tren cloumn category của cái table products
create NONCLUSTERED INDEX IX_product_category on products(category);

-- xóa index
drop Index  IX_product_category on products



SET STATISTICS IO ON;
SET STATISTICS TIME ON;


    DECLARE @StartTime DATETIME2 = SYSDATETIME();  

    SELECT * FROM products where  category  = 'Clothing';


    DECLARE @EndTime DATETIME2 = SYSDATETIME();  

    -- Hiển thị thời gian chạy
    SELECT DATEDIFF(MILLISECOND, @StartTime, @EndTime) AS ExecutionTime_ms;
--- procedured trong sql server
    -- thay vì tạo nhiều insert qua nhiều table thì chỉ cần dùng procedured
    --- + tập hợp các câu lệnh sql và được lưu trữ trong sql server
    	--- và có thể thực thi nhiều lần và ko cần viết lại
    --- + bảo mật dữ liệu: giảm rủi ro injection khi xử lý tham số đàu vào 
    --- + Giảm tải băng thông: chỉ cần gửi một lệnh procedure 
    -- transaction, trigger : chỉ áp dụng nhiều banking
    
   Create procedure getAllProduct
   as 
   begin
   		SELECT * FROM products
	end;
   
   -- thực thi procedure
   
   EXEC getAllProduct

   --- define procedure co tham so truyen vao 
   
   	create procedure getAllProductBycategory @category NVarchar(50)
   	as
   	begin
   		SELECT * FROM products where category = @category
   	end
   	
   	EXEC getAllProductBycategory 'Clothing'
   	
   	-- procedure add thanh cong va thong bao
   	create procedure addProduct
   	@name nvarchar(100),
   	@price decimal(10,2),
   	@category nvarchar(50)
   	as
   	begin
   		INSERT into products (name, price,category)
   		VALUES(@name,@price,@category)
   		SELECT N'SAN PHAM' + @name +N'ADD sucessfully' as MESSAGE;
   	end
   	
   	EXEC addProduct 'Laptop', 1200, 'Electronics'
   
   	
   
   
