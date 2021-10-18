CREATE TABLE Todo (
  Id int(10) unsigned NOT NULL AUTO_INCREMENT,
  Description nvarchar(100) NOT NULL,
  PRIMARY KEY (Id)
);

INSERT INTO Todo(Description) VALUES
('Bungee jumping'),
('Parachuting');