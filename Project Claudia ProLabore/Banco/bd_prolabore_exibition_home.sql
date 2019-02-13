CREATE DATABASE  IF NOT EXISTS `bd_prolabore` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `bd_prolabore`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: localhost    Database: bd_prolabore
-- ------------------------------------------------------
-- Server version	5.6.21-enterprise-commercial-advanced-log

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
-- Table structure for table `exibition_home`
--

DROP TABLE IF EXISTS `exibition_home`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exibition_home` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `user` int(11) NOT NULL,
  `img_home` varchar(200) NOT NULL,
  `sobre` text NOT NULL,
  `titulo` varchar(30) DEFAULT NULL,
  `text` varchar(100) DEFAULT NULL,
  `titulo2` varchar(30) DEFAULT NULL,
  `text2` varchar(100) DEFAULT NULL,
  `titulo3` varchar(30) DEFAULT NULL,
  `text3` varchar(100) DEFAULT NULL,
  `hora` time NOT NULL,
  `data` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exibition_home`
--

LOCK TABLES `exibition_home` WRITE;
/*!40000 ALTER TABLE `exibition_home` DISABLE KEYS */;
INSERT INTO `exibition_home` VALUES (1,0,'img/imagens/02022017323210.jpg','Era uma vez uma linda criança que andava na rua sem saber para onde ir. Um belo dia, andando sozinha Satanais a pegou para virar \"a coisa ruim no mundo\", vendo sendo desfeito a criança ficou muito triste. Vendo toda aquela coisa ruim, o cenário extremamente triste, o pastor da Assembleia de Deus fez com que a criança saísse da terra para virar uma criança cristã, uma pessoa de Deus, ou melhor, mais uma ovelhinha do Pastor Airton José Roubão Alves. ','wilson','teste1','wilson1','teste1','wilson2','teste2','10:32:32','2017-02-02');
/*!40000 ALTER TABLE `exibition_home` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-21 13:07:12
