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
-- Table structure for table `exib_gallery`
--

DROP TABLE IF EXISTS `exib_gallery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exib_gallery` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `title` varchar(40) NOT NULL,
  `text` varchar(100) DEFAULT NULL,
  `type` int(1) NOT NULL,
  `img` varchar(200) DEFAULT NULL,
  `video` varchar(100) DEFAULT NULL,
  `data` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exib_gallery`
--

LOCK TABLES `exib_gallery` WRITE;
/*!40000 ALTER TABLE `exib_gallery` DISABLE KEYS */;
INSERT INTO `exib_gallery` VALUES (14,'testeste','esse é um teste federal que tal fazer o teu também',1,'img/gallery/02022017575712.jpg',NULL,'2017-02-02'),(15,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(16,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(17,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(18,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(19,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(20,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(21,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(22,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02'),(23,'teste','asdasdasd',2,'img/gallery/02022017575712.jpg','https://www.youtube.com/embed/XP9B-ZQx3Yc','2017-02-02');
/*!40000 ALTER TABLE `exib_gallery` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-21 13:07:11
