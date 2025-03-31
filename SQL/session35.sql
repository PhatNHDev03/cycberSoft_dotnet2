use product_management
create table categories(
	ID int primary key identity (1,1),
	name nvarchar(255),
	description nvarchar(500)
)

INSERT INTO categories (name, description)
VALUES 
('Electronics', 'Devices and gadgets including phones, laptops, and accessories.'),
('Clothing', 'Men and women fashion including shirts, pants, and accessories.'),
('Home Appliances', 'Household appliances such as refrigerators, washing machines, and microwaves.'),
('Books', 'A collection of fiction, non-fiction, and educational books.'),
('Sports & Outdoors', 'Sports gear, fitness equipment, and outdoor adventure accessories.'),
('Toys & Games', 'Board games, puzzles, action figures, and learning toys for kids.'),
('Automotive', 'Car accessories, spare parts, and maintenance tools.'),
('Furniture', 'Home and office furniture including chairs, tables, and beds.'),
('Beauty & Personal Care', 'Cosmetics, skincare, haircare, and grooming products.'),
('Health & Wellness', 'Supplements, medical equipment, and wellness products.'),
('Music & Instruments', 'Musical instruments, accessories, and audio equipment.'),
('Groceries', 'Everyday food items, beverages, and household essentials.'),
('Jewelry & Watches', 'Luxury and fashion jewelry including rings, bracelets, and watches.'),
('Pet Supplies', 'Food, toys, and accessories for pets.'),
('Office Supplies', 'Stationery, printers, and office equipment.'),
('Gaming', 'Consoles, video games, and gaming accessories.'),
('Handmade & Crafts', 'Handmade decorations, DIY kits, and artistic supplies.'),
('Baby & Kids', 'Baby care products, clothing, and accessories.'),
('Garden & Tools', 'Gardening tools, plants, and outdoor maintenance equipment.'),
('Industrial & Scientific', 'Lab equipment, safety gear, and industrial tools.');
select * from categories

create table suppliers (
	ID int primary key identity (1,1),
	name nvarchar (255),
	email  varchar (255) unique,
	phone varchar(12)
)

INSERT INTO suppliers (name, email, phone)
VALUES 
('Tech Haven', 'contact@techhaven.com', '1234567890'),
('Fashion World', 'support@fashionworld.com', '0987654321'),
('Home Essentials', 'sales@homeessentials.com', '1122334455'),
('Book Haven', 'info@bookhaven.com', '2233445566'),
('Fit & Active', 'hello@fitactive.com', '3344556677'),
('Toy Kingdom', 'sales@toykingdom.com', '4455667788'),
('Auto Parts Depot', 'service@autopartsdepot.com', '5566778899'),
('Comfort Living', 'support@comfortliving.com', '6677889900'),
('Glow Beauty', 'contact@glowbeauty.com', '7788990011'),
('Wellness Hub', 'care@wellnesshub.com', '8899001122'),
('Sound Waves', 'hello@soundwaves.com', '9900112233'),
('Fresh Mart', 'support@freshmart.com', '1010101010'),
('Gold & Gems', 'sales@goldgems.com', '1112223333'),
('Pet Paradise', 'contact@petparadise.com', '2223334444'),
('Office Supplies Co.', 'info@officesuppliesco.com', '3334445555'),
('Game Universe', 'support@gameuniverse.com', '4445556666'),
('Artisan Creations', 'hello@artisancreations.com', '5556667777'),
('Baby Bliss', 'sales@babybliss.com', '6667778888'),
('Garden Experts', 'info@gardenexperts.com', '7778889999'),
('Industrial Solutions', 'support@industrialsolutions.com', '8889990000');

create table  customers (
	ID int primary key identity (1,1),
	name nvarchar (255),
	email varchar  (255),
	address nvarchar (500)
)
select * from customers


INSERT INTO customers (name, email, address)
VALUES 
('John Doe', 'johndoe@example.com', '123 Main St, Springfield, IL'),
('Jane Smith', 'janesmith@example.com', '456 Elm St, Los Angeles, CA'),
('Michael Johnson', 'michaelj@example.com', '789 Oak Ave, Houston, TX'),
('Emily Davis', 'emilyd@example.com', '321 Pine Rd, Miami, FL'),
('David Martinez', 'davidm@example.com', '654 Cedar Ln, Seattle, WA'),
('Sarah Wilson', 'sarahw@example.com', '987 Maple Blvd, New York, NY'),
('James Brown', 'jamesb@example.com', '147 Birch St, Chicago, IL'),
('Linda Taylor', 'lindat@example.com', '258 Walnut Ave, Boston, MA'),
('Robert Anderson', 'roberta@example.com', '369 Chestnut Rd, Dallas, TX'),
('Jessica Thomas', 'jessicat@example.com', '753 Spruce St, Phoenix, AZ'),
('Daniel White', 'danielw@example.com', '159 Redwood Ave, San Diego, CA'),
('Laura Harris', 'laurah@example.com', '357 Aspen Ln, Denver, CO'),
('William Clark', 'williamc@example.com', '951 Cypress Blvd, San Francisco, CA'),
('Olivia Lewis', 'olivial@example.com', '852 Palm St, Atlanta, GA'),
('Christopher Walker', 'chrisw@example.com', '654 Sycamore Rd, Austin, TX'),
('Sophia Hall', 'sophiah@example.com', '357 Magnolia St, Orlando, FL'),
('Matthew Allen', 'matthewa@example.com', '789 Fir Ave, Portland, OR'),
('Emma Young', 'emmay@example.com', '951 Holly Blvd, Charlotte, NC'),
('Ethan King', 'ethank@example.com', '123 Willow Rd, Nashville, TN'),
('Ava Scott', 'avas@example.com', '456 Dogwood Ln, Las Vegas, NV');

create table products (
	ID int primary key identity (1,1),
	name Nvarchar (255), 
	price decimal (10,2),
	stock int,
	supplierId int foreign key  References  suppliers (ID),
	categoryId int foreign key references  categories(ID)

)

INSERT INTO products (name, price, stock, supplierId, categoryId)
VALUES 
('iPhone 14', 999.99, 50, 1, 1),
('Samsung Galaxy S23', 899.99, 40, 1, 1),
('HP Laptop 15"', 749.99, 30, 1, 1),
('Nike Running Shoes', 120.50, 100, 2, 2),
('Adidas Hoodie', 85.00, 80, 2, 2),
('LG Smart TV 55"', 599.99, 25, 3, 3),
('Whirlpool Refrigerator', 899.00, 15, 3, 3),
('The Great Gatsby', 15.99, 200, 4, 4),
('Dumbbells 10KG Set', 45.00, 60, 5, 5),
('Yoga Mat', 25.50, 75, 5, 5),
('Lego Star Wars Set', 99.99, 40, 6, 6),
('Hot Wheels Car Pack', 20.00, 150, 6, 6),
('Michelin Car Tires', 299.99, 20, 7, 7),
('Gaming Office Chair', 189.99, 30, 8, 7),
('Skincare Set', 79.99, 60, 9, 9),
('Hair Dryer', 49.50, 50, 9, 9),
('Vitamin C Supplement', 29.99, 100, 10, 10),
('Acoustic Guitar', 199.99, 25, 11, 11),
('Noise-Canceling Headphones', 149.99, 50, 11, 11),
('Organic Green Tea', 15.00, 200, 12, 12),
('Gold Necklace', 499.99, 10, 13, 13),
('Dog Food 5KG', 35.00, 80, 14, 14),
('Printer HP LaserJet', 179.99, 20, 15, 15),
('PlayStation 5', 499.99, 15, 16, 16),
('DIY Painting Kit', 30.00, 50, 17, 17);



create table orders (
	ID int primary key identity (1,1),
	customerId int foreign key references customers(ID),
	orderDate DateTime default GETDATE()

)
INSERT INTO orders (customerId, orderDate)
VALUES 
(1, '2024-03-01 10:15:00'),
(2, '2024-03-02 14:30:00'),
(3, '2024-03-03 09:45:00'),
(4, '2024-03-04 16:20:00'),
(5, '2024-03-05 11:10:00'),
(6, '2024-03-06 18:05:00'),
(7, '2024-03-07 13:25:00'),
(8, '2024-03-08 08:40:00'),
(9, '2024-03-09 15:50:00'),
(10, '2024-03-10 12:30:00'),
(11, '2024-03-11 17:10:00'),
(12, '2024-03-12 09:00:00'),
(13, '2024-03-13 14:45:00'),
(14, '2024-03-14 19:30:00'),
(15, '2024-03-15 11:55:00'),
(16, '2024-03-16 16:40:00'),
(17, '2024-03-17 10:20:00'),
(18, '2024-03-18 13:15:00'),
(19, '2024-03-19 08:50:00'),
(20, '2024-03-20 18:25:00');

create table orderDetails (
	ID int primary key identity (1,1),
	orderID int foreign key references orders(ID),
	productID int foreign key references products (ID) On delete cascade,
	quantity int,
	price decimal (10,2)
)


INSERT INTO orderDetails (orderID, productID, quantity, price)
VALUES 
(1, 3, 2, 749.99),
(1, 5, 1, 85.00),
(2, 8, 3, 15.99),
(2, 12, 2, 20.00),
(3, 15, 1, 49.50),
(3, 18, 1, 199.99),
(4, 6, 1, 599.99),
(4, 9, 2, 45.00),
(5, 14, 1, 189.99),
(6, 11, 3, 99.99),
(6, 20, 2, 15.00),
(7, 7, 1, 299.99),
(8, 2, 1, 899.99),
(9, 17, 2, 29.99),
(10, 21, 1, 499.99),
(11, 24, 1, 499.99),
(12, 25, 2, 30.00),
(13, 10, 1, 25.50),
(14, 16, 2, 79.99),
(15, 19, 1, 149.99);
-----



select * from suppliers
select p.name as productName, p.price,p.stock,s.name,s.email, c.name as categoryName from products p join suppliers s on p.supplierId = s.ID
join categories c on p.categoryId = c.ID


---------- 4
SELECT o.ID as orderID, o.orderDate,c.name, c.email FROM orders o  join customers c on o.customerId = c.ID



SELECT od.ID,od.quantity,od.price,p.name FROM  orderDetails od join products p on od.productID = p.ID



--------- 5 Tính tổng số lượng sản phẩm tồn kho của từng danh mục.
select sum (stock) as totalStock, categories.name FROM products join categories on products.categoryId = categories.ID  group by categories.name
order by totalStock DESc
---------6 Lấy danh sách danh mục chưa có sản phẩm nào.
select  * FROM products right join categories on products.categoryId = categories.ID  where products.categoryId is null
--------- Tìm sản phẩm có giá cao nhất trong mỗi danh mục.

select Max (price) as totalStock, categories.name FROM products join categories on products.categoryId = categories.ID  group by categories.name
order by totalStock DESc
----Danh sách khách hàng có tổng số tiền mua hàng nhiều nhất (tính tổng từ OrderDetails).
SElect sum(od.price*od.quantity) as total, c.name FROm customers c join orders o on c.ID = o.customerId join orderDetails od on  od.orderID = o.ID group by  c.name
order by total DESC -- doc cai ane  no cung 1 nhieu cung la 1 name 1 record nhu ordeid
-------Tính tổng doanh thu của từng nhà cung cấp dựa trên số lượng sản phẩm đã bán.





