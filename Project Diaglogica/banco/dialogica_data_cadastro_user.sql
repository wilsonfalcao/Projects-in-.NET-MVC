CREATE DATABASE  IF NOT EXISTS `psidialogica_com_br` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `psidialogica_com_br`;
-- MySQL dump 10.13  Distrib 5.6.18, for Win32 (x86)
--
-- Host: localhost    Database: psidialogica_com_br
-- ------------------------------------------------------
-- Server version	5.6.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cadastro_user`
--

DROP TABLE IF EXISTS `cadastro_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cadastro_user` (
  `ln` int(9) NOT NULL AUTO_INCREMENT,
  `id` bigint(10) NOT NULL,
  `nome` varchar(40) NOT NULL,
  `sexo` char(1) NOT NULL,
  `cpf` varchar(11) NOT NULL,
  `dnt` date NOT NULL,
  `tel` varchar(11) NOT NULL,
  `email` varchar(30) NOT NULL,
  `tp_end` varchar(11) NOT NULL,
  `end` varchar(45) NOT NULL,
  `bairro` varchar(35) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `estado` char(2) NOT NULL,
  `nm` varchar(10) NOT NULL,
  `data` date NOT NULL,
  PRIMARY KEY (`ln`,`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cadastro_user`
--

LOCK TABLES `cadastro_user` WRITE;
/*!40000 ALTER TABLE `cadastro_user` DISABLE KEYS */;
INSERT INTO `cadastro_user` VALUES (16,12,'wilson','M','07868781424','1991-09-30','8195189940','wilson.falcao1@hotmail.com','casa','2º travessa belo campo','piedade','jaboatao','p','140','2015-06-28'),(17,13,'carlos','M','10265899400','1991-08-30','8195189940','wilson.falcao1@gmail.com','casa','2º travessa belo campo','piedade','jaboatao','p','140','2015-06-28');
/*!40000 ALTER TABLE `cadastro_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-08-23  0:23:52
