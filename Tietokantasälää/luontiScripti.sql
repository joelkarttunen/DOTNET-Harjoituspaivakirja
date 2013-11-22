DROP TABLE IF EXISTS Suoritus;

DROP TABLE IF EXISTS Kayttaja;

CREATE TABLE Kayttaja (
  Kayttaja_ID INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  e_nimi VARCHAR(20)  NULL  ,
  s_nimi VARCHAR(45)  NULL  ,
  ika INTEGER UNSIGNED  NULL  ,
  asuinpaikka VARCHAR(45)  NULL  ,
  kayttajatunnus VARCHAR(20)  NOT NULL  ,
  salasana VARCHAR(20)  NOT NULL  ,
  lisatietoa VARCHAR(255)  NULL  ,
  hetu VARCHAR(20)  NULL  ,
  rekisteroitymisPvm DATE  NULL  ,
  email VARCHAR(45)  NULL    ,
PRIMARY KEY(Kayttaja_ID))
TYPE=InnoDB;



CREATE TABLE Suoritus (
  Suoritus_ID INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Kayttaja_ID INTEGER UNSIGNED  NOT NULL  ,
  Alkuaika DATETIME  NULL  ,
  Loppuaika DATETIME  NULL  ,
  laji VARCHAR(20)  NULL  ,
  tuntemukset VARCHAR(255)  NULL    ,
PRIMARY KEY(Suoritus_ID, Kayttaja_ID),
  FOREIGN KEY(Kayttaja_ID)
    REFERENCES Kayttaja(Kayttaja_ID)
      ON DELETE CASCADE
      ON UPDATE CASCADE)
TYPE=InnoDB;




