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
-- Table structure for table `profissionais`
--

DROP TABLE IF EXISTS `profissionais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profissionais` (
  `ln` int(11) NOT NULL AUTO_INCREMENT,
  `id` int(11) NOT NULL,
  `img_src` varchar(300) NOT NULL,
  `nome` varchar(40) NOT NULL,
  `funcao` varchar(30) NOT NULL,
  `tp_profissional` bit(1) NOT NULL,
  `crp` varchar(10) NOT NULL,
  `dt` bit(1) NOT NULL,
  `turno` varchar(10) NOT NULL,
  `frase` varchar(300) NOT NULL,
  `linkedin` varchar(45) DEFAULT NULL,
  `facebook` varchar(50) DEFAULT NULL,
  `tel` varchar(10) NOT NULL,
  `data_adm` date NOT NULL,
  PRIMARY KEY (`ln`,`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Cadastro de Profissionais';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profissionais`
--

LOCK TABLES `profissionais` WRITE;
/*!40000 ALTER TABLE `profissionais` DISABLE KEYS */;
INSERT INTO `profissionais` VALUES (2,12,'http://www.raizesefac.com.br/images/fotousuario34.jpg','Ana Cristina','Psicologa','','02/17842','','Noite','Psicóloga Clínica formada pela Faculdade de Ciências Humanas – ESUDA- Pós-Graduanda em Intervenções Psicossociais e Comunitária pela FAFIRE. Profissional com experiência Clínica, Organizacional e Social; Acompanhamento Psicoterapêutico para: Adolescentes, Adultos e Idosos.','','https://www.facebook.com/anacrissol?fref=ts','95189940','2015-04-19'),(3,10,'http://www.raizesefac.com.br/images/fotousuario34.jpg','Analia Fernandes','Psicologa','','02/17843','','Tarde','Profissional com experiência clínica, organizacional e social. Em consultório, realizo as seguintes atividades: psicoterapia adulto, criança, adolescente e idoso, supervisão clínica na abordagem fenomenológico-existencial.','','https://www.facebook.com/analiafer.aninh','95189940','2015-04-19'),(4,15,'http://www.raizesefac.com.br/images/fotousuario34.jpg','Marinês Resende','Psicologa','','02/17841','','Tarde','Profissional com experiência clinica, escolar e intervenção social. Atividades; realizo psicoterapias em adolescentes, adultos e idosos.',NULL,'https://www.facebook.com/marines.resende?fref=ts','95184747','2015-04-25');
/*!40000 ALTER TABLE `profissionais` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-08-23  0:24:03
