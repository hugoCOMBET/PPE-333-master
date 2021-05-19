drop database if exists LSRGames ;
create database LSRGames;
use LSRGames;

create table Utilisateur(
id int,
Login varchar(75) unique,
MotDePasse varchar(30),
primary key(id)
) engine InnoDB;

create table Client(
id int,
nom varchar(30),
prenom varchar(30),
photo varchar(200),
adresse varchar(150),
DateNaissance date,
Email varchar(150),
TelephonePortable char(10), 
Credit double,
primary key(id)
) engine InnoDB;

create table Obstacle(
nom varchar(100),
UneDefinition varchar(255),
Photo blob,
typeObstacle varchar(75),
primary key(nom)
)engine InnoDB;

create table Themes(
id int,
theme varchar(50),
primary key(id)
)engine InnoDB;

create table Salle(
idSalle int,
ville varchar(45),
idTheme int,
primary key(idSalle),
foreign key (idTheme) references Themes(id) on update cascade on delete cascade
)engine InnoDB;

create table Transactions(
id int,
idClient int,
MontantTransaction double,
primary key(id),
foreign key(idClient) references Client(id) on update cascade on delete cascade
) engine InnoDB;

create table Reservation(
idReservation int,
idClient int,
jour date,
heure time,
nbJoueurs int check(nbJoueurs <=7),
nbObstacle int check(nbObstacle <=12),
idSalle int,
idTransaction int,
primary key(idReservation),
foreign key(idClient) references Client(id) on update cascade on delete cascade,
foreign key(idSalle) references Salle(idSalle) on update cascade on delete cascade,
foreign key(idTransaction) references Transactions(id) on update cascade on delete cascade
) engine InnoDB;

create table Avis(
idAvis int auto_increment,
idClient int,
idSalle int,
avis varchar(255),
primary key(idAvis),
foreign key(idClient) references Client(id) on update cascade on delete cascade,
foreign key(idSalle) references Salle(idSalle) on update cascade on delete cascade
)engine InnoDB;

create table PositionObstacle(
idPositionObstacle int auto_increment,
nomObstacle varchar(100),
idReservation int,
PositionObstacle int check(PositionObstacle <=12),
primary key(idPositionObstacle),
foreign key(nomObstacle) references Obstacle(nom) on update cascade on delete cascade,
foreign key(idReservation) references Reservation(idReservation) on update cascade on delete cascade
)engine InnoDB;

insert into Client values (1,"hugo","combet","hh","jj",'2020-06-20',"kk",0782333019,0);
insert into Client values (2,"hugo","combet","hh","jj",'2020-06-20',"kk",0782333019,0);

select * from Client;

insert into Transactions values(1,2,20);
insert into Transactions values(2,1,200);
select * from Transactions;