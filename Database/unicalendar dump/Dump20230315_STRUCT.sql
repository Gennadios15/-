-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: classes
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `idCategory` int NOT NULL,
  `CategoryName` varchar(200) NOT NULL,
  `ParentCategoryID` int NOT NULL,
  PRIMARY KEY (`idCategory`),
  UNIQUE KEY `ModulesCategory_UNIQUE` (`CategoryName`),
  UNIQUE KEY `ParentCategoryID_UNIQUE` (`ParentCategoryID`),
  CONSTRAINT `idParentCategory` FOREIGN KEY (`ParentCategoryID`) REFERENCES `parentcategory` (`idParentCategory`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event` (
  `GoogleCalendarID` int NOT NULL,
  `EventId` int NOT NULL,
  `idmodule` int NOT NULL,
  `idlecturer` int NOT NULL,
  `EventName` varchar(100) NOT NULL,
  `Eventdetails` mediumtext NOT NULL,
  `EventStartsOn` date NOT NULL,
  `EventsEndsOn` date NOT NULL,
  PRIMARY KEY (`EventId`,`GoogleCalendarID`),
  KEY `fkLecturer_idx` (`idlecturer`),
  KEY `fkModule_idx` (`idmodule`),
  CONSTRAINT `fkLecturer` FOREIGN KEY (`idlecturer`) REFERENCES `lecturer` (`idLecturer`),
  CONSTRAINT `fkModule` FOREIGN KEY (`idmodule`) REFERENCES `modules` (`idModules`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `interest`
--

DROP TABLE IF EXISTS `interest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `interest` (
  `idInterest` int NOT NULL,
  `ModuleID` int NOT NULL,
  `EventID` int NOT NULL,
  `Username` varchar(45) NOT NULL,
  `Comment` varchar(200) DEFAULT NULL,
  `Email` varchar(45) NOT NULL,
  PRIMARY KEY (`idInterest`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interest`
--

LOCK TABLES `interest` WRITE;
/*!40000 ALTER TABLE `interest` DISABLE KEYS */;
/*!40000 ALTER TABLE `interest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lecturer`
--

DROP TABLE IF EXISTS `lecturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lecturer` (
  `idLecturer` int NOT NULL,
  `LecturerName` varchar(45) NOT NULL,
  `LecturerBio` mediumtext NOT NULL,
  `LecturerURL` varchar(255) NOT NULL,
  `LecturerPhoto` blob,
  `LecturerEmail` varchar(60) NOT NULL,
  `LecturerRoles` varchar(255) NOT NULL,
  PRIMARY KEY (`idLecturer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lecturer`
--

LOCK TABLES `lecturer` WRITE;
/*!40000 ALTER TABLE `lecturer` DISABLE KEYS */;
/*!40000 ALTER TABLE `lecturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulecategories`
--

DROP TABLE IF EXISTS `modulecategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modulecategories` (
  `idModule` int NOT NULL,
  `IdCategory` int NOT NULL,
  `SinceWhen` date NOT NULL,
  PRIMARY KEY (`idModule`,`IdCategory`),
  KEY `categories_idx` (`IdCategory`),
  CONSTRAINT `categories` FOREIGN KEY (`IdCategory`) REFERENCES `categories` (`idCategory`),
  CONSTRAINT `Modules` FOREIGN KEY (`idModule`) REFERENCES `modules` (`idModules`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulecategories`
--

LOCK TABLES `modulecategories` WRITE;
/*!40000 ALTER TABLE `modulecategories` DISABLE KEYS */;
/*!40000 ALTER TABLE `modulecategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modules`
--

DROP TABLE IF EXISTS `modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modules` (
  `idModules` int NOT NULL,
  `ModuleName` varchar(250) NOT NULL,
  `ModuleDesc` mediumtext NOT NULL,
  `CreatedSince` date NOT NULL,
  `TotalHours` int NOT NULL,
  `Lectures` int NOT NULL,
  `ModuleLeader` int NOT NULL,
  `GoogleCalendarID` varchar(40) NOT NULL,
  `GoogleCalendarTitle` varchar(200) NOT NULL,
  `ModuleURL` varchar(200) DEFAULT NULL,
  `ModuleVideoURL` varchar(200) DEFAULT NULL,
  `ModuleFacebookGroup` varchar(200) DEFAULT NULL,
  `Price` decimal(10,0) NOT NULL,
  `Online` varchar(10) NOT NULL,
  `Room` varchar(45) DEFAULT NULL,
  `OnlineMethod` varchar(45) DEFAULT NULL,
  `Rating` int NOT NULL,
  `Tags` varchar(100) DEFAULT NULL,
  `Active` varchar(10) NOT NULL,
  `Lab` varchar(10) NOT NULL,
  `Book` varchar(10) NOT NULL,
  `ModuleType` varchar(45) NOT NULL,
  PRIMARY KEY (`idModules`),
  UNIQUE KEY `idModules_UNIQUE` (`idModules`),
  UNIQUE KEY `ModuleName_UNIQUE` (`ModuleName`),
  KEY `ModuleLeader_idx` (`ModuleLeader`),
  CONSTRAINT `ModuleCategory` FOREIGN KEY (`idModules`) REFERENCES `modulecategories` (`idModule`) ON UPDATE CASCADE,
  CONSTRAINT `ModuleLeader` FOREIGN KEY (`ModuleLeader`) REFERENCES `lecturer` (`idLecturer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modules`
--

LOCK TABLES `modules` WRITE;
/*!40000 ALTER TABLE `modules` DISABLE KEYS */;
/*!40000 ALTER TABLE `modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parentcategory`
--

DROP TABLE IF EXISTS `parentcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `parentcategory` (
  `idParentCategory` int NOT NULL,
  `parentCategoryName` varchar(200) NOT NULL,
  PRIMARY KEY (`idParentCategory`),
  UNIQUE KEY `parentCategoryName_UNIQUE` (`parentCategoryName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parentcategory`
--

LOCK TABLES `parentcategory` WRITE;
/*!40000 ALTER TABLE `parentcategory` DISABLE KEYS */;
/*!40000 ALTER TABLE `parentcategory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-05  3:09:55
