-- cap quyen user toan quyens erver
--quyen tren server
--toan quyen
CREATE LOGIN HoangPHat with password = 'Phat@2003'
create user HoangPHat for Login HoangPHat;
ALter  ROLE sysAdmin add member  HoangPHat;

CREATE LOGIN DuyPhuong with password = 'Phat@2003'
create user DuyPhuong for Login DuyPhuong;
ALter  ROLE tech add member  DuyPhuong;


-- quyen tren database
CREATE LOGIN Tuan with password = 'Phat@2003'
create user Tuan for Login Tuan;
ALter  ROLE db_owner add member  Tuan;
create database session36;

create table restaurant (
	ID int primary key identity (1,1),
	name nvarcahr(255)
)


create table food_type(
	ID int primary key identity (1,1),
	name nvarcahr(255)
)
-- cap quyne user cho table restaurant
CREATE LOGIN ThanhTri with password = 'Phat@2003'
create user ThanhTri for Login ThanhTri;
Grant SELECT ON dbo.restaurant to  ThanhTri;
Grant Insert ON dbo.restaurant to  ThanhTri;
--- select , update, delete, insert


-- thu hoi quyen 
REvoke  Insert ON dbo.restaurant to  ThanhTri;
-- chan quyen 
deny select on  dbo.restaurant to  ThanhTri;
