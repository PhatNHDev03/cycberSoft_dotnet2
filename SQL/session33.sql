-- tao doan database
create database dotnet;

use dotnet

-- 1 so tool truc quan nhin data
--power BI
--tableau
-- thuong thi co 1 so backup database

--tao table
-- quay uoc dat ten table
--dat ten column ko co dau
create table users(
	-- <ten column> <keiu du lieu> <constraint (neu co)>
	--number : nguyen, thuc 
	-- string: 
	--dateTime
	--json,xml 	
	-- Identity dung de tao gia tri tu dong tang
	user_id int Identity (1,1),	
	full_name VARCHAR(50),
	email VARCHAR(255) unique,
	password VARCHAR(255),age int 
)

-- insert data vao table
INSERT INTO users (full_name,email ,password ) VALUES
('Nguyewn Van A', 'VanA@gmail.com', '123456'),
('Son Tung', 'SonTUng@gmail.com', '123456')

--- bai 1 liet ke nhung nguoi co tu tuoi tu 20 den 25 sap xep theo tuoi giam dan 
SELECT * FROm users where age BEtween 20 and 25
----- c2 : 
SELECT * FROm users where 20 <= age ANd age>=25 Order by age ASC

-- quicl sort --> neu data lon
-- insertion sort bigO (n^2) nhung nhieu phan no nhanh hon moi thg n^2 --> neu data nho
--cui` bap nhat la interchange 
-- nlog: quicksort, merge , heap sort
--- sua lai table
-- them column moi

-- bai 2: in ra nhung ng co tuoi lon nhat 
SELECT * FROm users where age = (
	SELECT TOP 1 age FROM users ORDER By age Desc 
) 
SELECT * FROM users where age = (
	SELECT MAX(age)FROM users
)


ALter TAble  users
Add age int 
-- xoa column
ALter TAble  users
Drop Column password 
-- doi datatype cho column nao do
Alter Table users
Alter Column full_name VARCHAR(100)
-- xoa table 
DRop table users



INSERT INTO users (full_name, email, password, age)  
VALUES  
(N'Nguyễn Văn A', 'nguyenvana@example.com', 'password123', 25),  
(N'Trần Thị B', 'tranthib@example.com', 'securepass456', 30),  
(N'Lê Văn C', 'levanc@example.com', 'mypassword789', 28),  
(N'Phạm Thị D', 'phamthid@example.com', 'abc123xyz', 22),  
(N'Hoàng Văn E', 'hoangvane@example.com', 'pass@word1', 35),  
(N'Đặng Thị F', 'dangthif@example.com', 'letmein789', 27),  
(N'Võ Văn G', 'vovang@example.com', 'qwertyuiop', 24),  
(N'Bùi Thị H', 'buithih@example.com', 'pa$$w0rd', 31),  
(N'Đỗ Văn I', 'dovani@example.com', 'supersecure1', 29),  
(N'Ngô Thị J', 'ngothij@example.com', 'randompass123', 26),  
(N'Dương Văn K', 'duongvank@example.com', 'password321', 32),  
(N'Phan Thị L', 'phanthil@example.com', 'pass1234word', 23),  
(N'Tô Văn M', 'tovanm@example.com', 'mysecretpass', 27),  
(N'Lý Thị N', 'lythin@example.com', 'passw0rd@123', 30),  
(N'Hồ Văn O', 'hovano@example.com', 'letmeinpass', 28),  
(N'Trịnh Thị P', 'trinhthip@example.com', 'secret987', 34),  
(N'Nguyễn Văn Q', 'nguyenvanq@example.com', 'password567', 21),  
(N'Lâm Thị R', 'lamthir@example.com', 'pa$$word789', 26),  
('Châu Văn S', 'chauvans@example.com', 'securepa$$123', 29),  
(N'Vương Thị T', 'vuongthit@example.com', 'helloWorld987', 33);