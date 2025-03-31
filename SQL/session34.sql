-- cai SQL TREN DOCKER DE KETNOI
create database dotnet_session2

USE dotnet_session2



CREATE TABLE users(
	user_id int primary key identity (1,1),
	full_name nvarchar(255),
	email varchar(255) unique not null,
	password varchar(255)
)
INSERT INTO users (full_name, email, password) VALUES
(N'Nguyễn Văn An', 'an.nguyen@example.com', 'password123'),
(N'Trần Thị Bích', 'bich.tran@example.com', 'pass456'),
(N'Lê Hồng Phúc', 'phuc.le@example.com', 'secure789'),
(N'Hoàng Minh Châu', 'chau.hoang@example.com', 'mypassword'),
(N'Phạm Đức Duy', 'duy.pham@example.com', '12345678'),
(N'Bùi Thị Hạnh', 'hanh.bui@example.com', 'hello2024'),
(N'Đặng Quốc Trung', 'trung.dang@example.com', 'trungsecure'),
(N'Vũ Hải Yến', 'yen.vu@example.com', 'yensecret'),
(N'Ngô Đình Khánh', 'khanh.ngo@example.com', 'khanh123'),
(N'Đỗ Thanh Tùng', 'tung.do@example.com', 'tung456'),
(N'Nguyễn Thị Mai', 'mai.nguyen@example.com', 'mai999'),
(N'Hoàng Văn Tuấn', 'tuan.hoang@example.com', 'tuanpass'),
(N'Lý Quang Huy', 'huy.ly@example.com', 'huy12345'),
(N'Phan Thị Ngọc', 'ngoc.phan@example.com', 'ngocpass'),
(N'Đinh Tiến Dũng', 'dung.dinh@example.com', 'dungsecure'),
(N'Tống Minh Tú', 'tu.tong@example.com', 'tu654321'),
(N'Châu Gia Bảo', 'bao.chau@example.com', 'baosecret'),
(N'Vương Thị Lan', 'lan.vuong@example.com', 'lanpassword'),
(N'Hà Thế Hiển', 'hien.ha@example.com', 'hiensecure'),
(N'Lương Hoàng Nam', 'nam.luong@example.com', 'nam123456');

create table restaurant(
	res_id int primary key identity(1,1),
	res_name nvarchar(255),
	image varchar(255),
	description nvarchar(255)
);
INSERT INTO restaurant (res_name, image, description)  
VALUES  
(N'Nhà Hàng Sen Vàng', 'sen_vang.jpg', N'Không gian sang trọng, ẩm thực tinh tế'),  
(N'Quán Cơm Nhà', 'com_nha.jpg', N'Hương vị cơm nhà đậm đà, ấm cúng'),  
(N'Bún Bò Huế O Bê', 'bun_bo_hue.jpg', N'Chuyên các món bún bò Huế chính gốc'),  
(N'Phở Thìn Hà Nội', 'pho_thin.jpg', N'Phở truyền thống với nước dùng đậm đà'),  
(N'Lẩu Nấm Thiên Nhiên', 'lau_nam.jpg', N'Chuyên các món lẩu nấm tươi ngon'),  
(N'Gà Nướng Lu Đất', 'ga_nuong.jpg', N'Gà nướng theo phong cách dân dã'),  
(N'Hải Sản Biển Đông', 'hai_san.jpg', N'Hải sản tươi sống, chế biến theo yêu cầu'),  
(N'Chè Ngon 3 Miền', 'che_3_mien.jpg', N'Chè truyền thống từ Bắc - Trung - Nam'),  
(N'Bánh Xèo Cô Ba', 'banh_xeo.jpg', N'Bánh xèo giòn rụm, nước chấm đặc biệt'),  
(N'Quán Chay Tâm An', 'quan_chay.jpg', N'Món chay thanh đạm, tốt cho sức khỏe'),  
(N'Cơm Gà Xối Mỡ 68', 'com_ga.jpg', N'Gà giòn rụm, cơm dẻo thơm ngon'),  
(N'Nhà Hàng Đệ Nhất', 'de_nhat.jpg', N'Ẩm thực cao cấp, phục vụ chuyên nghiệp'),  
(N'Bún Chả Hà Thành', 'bun_cha.jpg', N'Bún chả nướng chuẩn vị Hà Nội'),  
(N'Nem Nướng Nha Trang', 'nem_nuong.jpg', N'Đặc sản nem nướng chấm nước sốt riêng'),  
(N'Bánh Mì 5 Sao', 'banh_mi.jpg', N'Bánh mì nóng giòn, nhân đa dạng'),  
(N'Nhà Hàng Cua Biển', 'cua_bien.jpg', N'Chuyên cua ghẹ, hải sản tươi ngon'),  
(N'Bò Né 3 Ngon', 'bo_ne.jpg', N'Bò né mềm thơm, bánh mì giòn tan'),  
(N'Mì Quảng Đà Thành', 'mi_quang.jpg', N'Mì Quảng đúng điệu với nước lèo đậm đà'),  
(N'Lẩu Gà Lá É', 'lau_ga.jpg', N'Lẩu gà với lá é thơm ngon, hấp dẫn'),  
(N'Nhà Hàng Ốc Ngon', 'oc_ngon.jpg', N'Ốc tươi, nhiều loại nước chấm đặc biệt');
SELECT * FROm  restaurant;

Create table like_res (
	like_res_id INT primary key identity(1,1),
	user_id int,
	res_id INT,
	Foreign key (user_id) references  users (user_id),
	Foreign key (res_id) references restaurant (res_id)
)

INSERT INTO like_res (user_id, res_id)  
VALUES  
(1, 3),  (1, 5),  (1, 7),  (1, 2),(2,8),
(2, 1),  (3, 6),  (2, 9),  (3, 4),  (10, 10),  
(11, 12),  (12, 14),  (13, 11),  (14, 15),  (15, 16),  
(16, 18),  (17, 19),  (18, 13),  (19, 20),  (20, 17);


--- tim 5 like nha hang nhieu nhat 
select TOP 5 count(like_res.res_id)  as count_like,users.full_name   FRom like_res join users on like_res.user_id  = users.user_id  group BY users.full_name 
order by count_like DESC 
---ham tong hop sum, min, max ,AVG --> kem theo column thi phai co group by 

create table rate_res(
	user_id int Foreign key references users(user_id),
	res_id int Foreign key (res_id) references restaurant (res_id),
	amount int 
)


INSERT INTO rate_res (user_id, res_id, amount)  
VALUES  
(1, 3, 5),  (2, 5, 4),  (3, 7, 3),  (4, 2, 5),  (5, 8, 2),  
(6, 1, 4),  (7, 6, 5),  (8, 9, 3),  (9, 4, 4),  (10, 10, 5),  
(11, 12, 2),  (12, 14, 3),  (13, 11, 4),  (14, 15, 5),  (15, 16, 1),  
(16, 18, 4),  (17, 19, 5),  (18, 13, 3),  (19, 20, 4),  (20, 17, 2),  
(1, 6, 5),  (2, 8, 4),  (3, 10, 3),  (4, 12, 5),  (5, 14, 1),  
(6, 16, 4),  (7, 18, 3),  (8, 20, 5),  (9, 11, 2),  (10, 13, 4);

select * from rate_res join  users on  rate_res.user_id = users.user_id
select *  from rate_res join  restaurant on  rate_res.res_id = restaurant.res_id  
--tim 5 nguoi danh gia nhieu nhat 

select TOP  5 count(rate_res.user_id) as rateting, users.full_name  from rate_res join  users on  rate_res.user_id = users.user_id group by users.full_name 
Order by rateting desc
-- tim nha hang co nhieu danh gia nhat
select TOP 2 count(rate_res.res_id) as rates, restaurant.res_name  from rate_res join  restaurant on  rate_res.res_id = restaurant.res_id  group by restaurant.res_name
Order by rates desc

--- tim user ko co hoat dong gi 
use dotnet_session2
SELECT * FROM rate_res
DELETE from  rate_res where user_id=7
SELECT * FROM users u left join like_res lr on u.user_id = lr.user_id
left join rate_res rr on rr.user_id = u.user_id where rr.user_id is null and lr.user_id is null