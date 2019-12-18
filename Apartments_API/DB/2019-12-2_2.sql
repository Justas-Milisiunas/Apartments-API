-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 02, 2019 at 07:21 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `apartments`
--

-- --------------------------------------------------------

--
-- Table structure for table `butas`
--

CREATE TABLE `butas` (
  `dydis` int(11) DEFAULT 0,
  `kambaru_skaicius` int(11) DEFAULT 0,
  `pridejimo_data` date,
  `kaina_uz_nakti` decimal(10,0) DEFAULT 0,
  `adresas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `nuotraukaURL` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT 'default.png',
  `aprašas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `pavadinimas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `miestas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `šalis` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `busena` int(11) DEFAULT NULL,
  `id_butas` int(11) NOT NULL,
  `fk_savininkasid_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `butas`
--

INSERT INTO `butas` (`dydis`, `kambaru_skaicius`, `pridejimo_data`, `kaina_uz_nakti`, `adresas`, `nuotraukaURL`, `aprašas`, `pavadinimas`, `miestas`, `šalis`, `busena`, `id_butas`, `fk_savininkasid_is_naudotojas`) VALUES
(55, 4, '2019-12-02', '15', 'gera gatve 15', 'default.png', 'geras butas', 'geras', 'Kaunas', 'Lietuva', 1, 1, 18);

-- --------------------------------------------------------

--
-- Table structure for table `buto_busena`
--

CREATE TABLE `buto_busena` (
  `id_buto_busena` int(11) NOT NULL,
  `NAME` char(10) COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `buto_busena`
--

INSERT INTO `buto_busena` (`id_buto_busena`, `NAME`) VALUES
(1, 'laisvas'),
(2, 'isnuomotas'),
(3, 'neaktyvus');

-- --------------------------------------------------------

--
-- Table structure for table `buto_laikotarpio_busena`
--

CREATE TABLE `buto_laikotarpio_busena` (
  `id_buto_laikotarpio_busena` int(11) NOT NULL,
  `NAME` char(10) COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `buto_laikotarpio_busena`
--

INSERT INTO `buto_laikotarpio_busena` (`id_buto_laikotarpio_busena`, `NAME`) VALUES
(1, 'sumoketa'),
(2, 'nesumoketa');

-- --------------------------------------------------------

--
-- Table structure for table `darbas`
--

CREATE TABLE `darbas` (
  `sukurimo_data` date DEFAULT NULL,
  `ivykdymo_data` date DEFAULT NULL,
  `uzmokestis` decimal(10,0) DEFAULT NULL,
  `busena` int(11) DEFAULT NULL,
  `id_darbas` int(11) NOT NULL,
  `fk_butasid_butas` int(11) NOT NULL,
  `fk_savininkasid_is_naudotojas` int(11) NOT NULL,
  `fk_valytojasid_is_naudotojas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `darbo_busena`
--

CREATE TABLE `darbo_busena` (
  `id_darbo_busena` int(11) NOT NULL,
  `NAME` char(10) COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `darbo_busena`
--

INSERT INTO `darbo_busena` (`id_darbo_busena`, `NAME`) VALUES
(1, 'atliktas'),
(2, 'priimtas'),
(3, 'laukiantis');

-- --------------------------------------------------------

--
-- Table structure for table `is_naudotojas`
--

CREATE TABLE `is_naudotojas` (
  `vardas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `el_pastas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `pavarde` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `paskutinis_prisijungimas` date,
  `registracijos_data` date,
  `slaptazodis` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `balansas` decimal(10,5) DEFAULT 0.00000,
  `id_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `is_naudotojas`
--

INSERT INTO `is_naudotojas` (`vardas`, `el_pastas`, `pavarde`, `paskutinis_prisijungimas`, `registracijos_data`, `slaptazodis`, `balansas`, `id_is_naudotojas`) VALUES
('Justas', 'justas@gmail.com', 'Karpis', NULL, NULL, 'namas', '0.00000', 17),
('Justas', 'jss@gmail.com', 'Karpis', '2019-11-29', '2019-11-29', 'namas', '0.00000', 18),
('Justas', 'jsss@gmail.com', 'Karpis', '2019-11-29', '2019-11-29', 'namas', '0.00000', 19),
('Justas', 'jssss@gmail.com', 'Karpis', '2019-11-29', '2019-11-29', 'namas', '0.00000', 20),
('Justas', 'jsssss@gmail.com', 'Karpis', '2019-11-29', '2019-11-29', 'namas', '0.00000', 21),
('asfasfas', 'sfasf@gmail.com', 'fasfasfasa', '2019-11-30', '2019-11-30', 'asdasda', '0.00000', 22),
('asdasda', 'dsdssd@gmail.com', 'asdd', '2019-11-30', '2019-11-30', 'namas', '0.00000', 25),
('fasas', 'ddasd@gmail.com', 'ffasf', '2019-11-30', '2019-11-30', 'asfasf', '0.00000', 26),
('asdasd', 'ddddd@gmail.com', 'dsda', '2019-11-30', '2019-11-30', 'asffasfasf', '0.00000', 27),
('dddsad', 'dsadasd@gmail.coma', 'ddsdsd', '2019-11-30', '2019-11-30', 'adsasfasfasf', '0.00000', 28),
('asdasd', 'asddd@asdasd.com', 'asdasd', '2019-11-30', '2019-11-30', 'asdasd', '0.00000', 29),
('asdasd', 'sdasdsa@fsasd.com', 'asdasda', '2019-11-30', '2019-11-30', 'asdasdas', '0.00000', 30),
('asdasd', 'sdassdsa@fsasd.com', 'asdasda', '2019-11-30', '2019-11-30', 'asdasdas', '0.00000', 31),
('adasd', 'tenant@gmail.com', 'asdasd', '2019-11-30', '2019-11-30', 'tenant', '0.00000', 32),
('asdasd', 'owner@gmail.com', 'dasdasd', '2019-11-30', '2019-11-30', 'owner', '0.00000', 33),
('asdasd', 'worker@gmail.com', 'dasd', '2019-11-30', '2019-11-30', 'worker', '0.00000', 34);

-- --------------------------------------------------------

--
-- Table structure for table `mokejimas`
--

CREATE TABLE `mokejimas` (
  `DATA` date DEFAULT NULL,
  `suma` decimal(10,0) DEFAULT NULL,
  `id_mokejimas` int(11) NOT NULL,
  `fk_nuomininkasid_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nuomininkas`
--

CREATE TABLE `nuomininkas` (
  `id_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `nuomininkas`
--

INSERT INTO `nuomininkas` (`id_is_naudotojas`) VALUES
(17),
(25),
(28),
(29),
(30),
(31),
(32);

-- --------------------------------------------------------

--
-- Table structure for table `nuomos_laikotarpis`
--

CREATE TABLE `nuomos_laikotarpis` (
  `nuo` date DEFAULT NULL,
  `iki` date DEFAULT NULL,
  `busena` int(11) DEFAULT NULL,
  `id_nuomos_laikotarpis` int(11) NOT NULL,
  `fk_nuomininkasid_is_naudotojas` int(11) NOT NULL,
  `fk_butasid_butas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `privalumas`
--

CREATE TABLE `privalumas` (
  `pavadinimas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `id_privalumas` int(11) NOT NULL,
  `fk_butasid_butas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `reitingas`
--

CREATE TABLE `reitingas` (
  `DATA` date DEFAULT NULL,
  `ivertinimas` int(11) DEFAULT NULL,
  `id_reitingas` int(11) NOT NULL,
  `fk_butasid_butas` int(11) NOT NULL,
  `fk_nuomininkasid_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `savininkas`
--

CREATE TABLE `savininkas` (
  `id_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `savininkas`
--

INSERT INTO `savininkas` (`id_is_naudotojas`) VALUES
(18),
(22),
(26),
(33);

-- --------------------------------------------------------

--
-- Table structure for table `skundas`
--

CREATE TABLE `skundas` (
  `DATA` date DEFAULT NULL,
  `pranesimas` varchar(255) COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `id_skundas` int(11) NOT NULL,
  `fk_butasid_butas` int(11) NOT NULL,
  `fk_nuomininkasid_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `valytojas`
--

CREATE TABLE `valytojas` (
  `id_is_naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `valytojas`
--

INSERT INTO `valytojas` (`id_is_naudotojas`) VALUES
(19),
(20),
(21),
(27),
(34);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `butas`
--
ALTER TABLE `butas`
  ADD PRIMARY KEY (`id_butas`),
  ADD KEY `busena` (`busena`),
  ADD KEY `turi` (`fk_savininkasid_is_naudotojas`);

--
-- Indexes for table `buto_busena`
--
ALTER TABLE `buto_busena`
  ADD PRIMARY KEY (`id_buto_busena`);

--
-- Indexes for table `buto_laikotarpio_busena`
--
ALTER TABLE `buto_laikotarpio_busena`
  ADD PRIMARY KEY (`id_buto_laikotarpio_busena`);

--
-- Indexes for table `darbas`
--
ALTER TABLE `darbas`
  ADD PRIMARY KEY (`id_darbas`),
  ADD KEY `busena` (`busena`),
  ADD KEY `priklauso` (`fk_butasid_butas`),
  ADD KEY `paskelbia` (`fk_savininkasid_is_naudotojas`),
  ADD KEY `priima` (`fk_valytojasid_is_naudotojas`);

--
-- Indexes for table `darbo_busena`
--
ALTER TABLE `darbo_busena`
  ADD PRIMARY KEY (`id_darbo_busena`);

--
-- Indexes for table `is_naudotojas`
--
ALTER TABLE `is_naudotojas`
  ADD PRIMARY KEY (`id_is_naudotojas`);

--
-- Indexes for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD PRIMARY KEY (`id_mokejimas`),
  ADD KEY `atlieka` (`fk_nuomininkasid_is_naudotojas`);

--
-- Indexes for table `nuomininkas`
--
ALTER TABLE `nuomininkas`
  ADD PRIMARY KEY (`id_is_naudotojas`);

--
-- Indexes for table `nuomos_laikotarpis`
--
ALTER TABLE `nuomos_laikotarpis`
  ADD PRIMARY KEY (`id_nuomos_laikotarpis`),
  ADD KEY `busena` (`busena`),
  ADD KEY `nuomoja` (`fk_nuomininkasid_is_naudotojas`),
  ADD KEY `yra_nuomojamas` (`fk_butasid_butas`);

--
-- Indexes for table `privalumas`
--
ALTER TABLE `privalumas`
  ADD PRIMARY KEY (`id_privalumas`),
  ADD KEY `turi2` (`fk_butasid_butas`);

--
-- Indexes for table `reitingas`
--
ALTER TABLE `reitingas`
  ADD PRIMARY KEY (`id_reitingas`),
  ADD KEY `skiriamas2` (`fk_butasid_butas`),
  ADD KEY `pateikia2` (`fk_nuomininkasid_is_naudotojas`);

--
-- Indexes for table `savininkas`
--
ALTER TABLE `savininkas`
  ADD PRIMARY KEY (`id_is_naudotojas`);

--
-- Indexes for table `skundas`
--
ALTER TABLE `skundas`
  ADD PRIMARY KEY (`id_skundas`),
  ADD KEY `skiriamas` (`fk_butasid_butas`),
  ADD KEY `pateikia` (`fk_nuomininkasid_is_naudotojas`);

--
-- Indexes for table `valytojas`
--
ALTER TABLE `valytojas`
  ADD PRIMARY KEY (`id_is_naudotojas`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `butas`
--
ALTER TABLE `butas`
  MODIFY `id_butas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `darbas`
--
ALTER TABLE `darbas`
  MODIFY `id_darbas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `is_naudotojas`
--
ALTER TABLE `is_naudotojas`
  MODIFY `id_is_naudotojas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `mokejimas`
--
ALTER TABLE `mokejimas`
  MODIFY `id_mokejimas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nuomos_laikotarpis`
--
ALTER TABLE `nuomos_laikotarpis`
  MODIFY `id_nuomos_laikotarpis` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `privalumas`
--
ALTER TABLE `privalumas`
  MODIFY `id_privalumas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reitingas`
--
ALTER TABLE `reitingas`
  MODIFY `id_reitingas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `skundas`
--
ALTER TABLE `skundas`
  MODIFY `id_skundas` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `butas`
--
ALTER TABLE `butas`
  ADD CONSTRAINT `butas_ibfk_1` FOREIGN KEY (`busena`) REFERENCES `buto_busena` (`id_buto_busena`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_savininkasid_is_naudotojas`) REFERENCES `savininkas` (`id_is_naudotojas`);

--
-- Constraints for table `darbas`
--
ALTER TABLE `darbas`
  ADD CONSTRAINT `darbas_ibfk_1` FOREIGN KEY (`busena`) REFERENCES `darbo_busena` (`id_darbo_busena`),
  ADD CONSTRAINT `paskelbia` FOREIGN KEY (`fk_savininkasid_is_naudotojas`) REFERENCES `savininkas` (`id_is_naudotojas`),
  ADD CONSTRAINT `priima` FOREIGN KEY (`fk_valytojasid_is_naudotojas`) REFERENCES `valytojas` (`id_is_naudotojas`),
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_butasid_butas`) REFERENCES `butas` (`id_butas`);

--
-- Constraints for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD CONSTRAINT `atlieka` FOREIGN KEY (`fk_nuomininkasid_is_naudotojas`) REFERENCES `nuomininkas` (`id_is_naudotojas`);

--
-- Constraints for table `nuomininkas`
--
ALTER TABLE `nuomininkas`
  ADD CONSTRAINT `nuomininkas_ibfk_1` FOREIGN KEY (`id_is_naudotojas`) REFERENCES `is_naudotojas` (`id_is_naudotojas`) ON DELETE CASCADE;

--
-- Constraints for table `nuomos_laikotarpis`
--
ALTER TABLE `nuomos_laikotarpis`
  ADD CONSTRAINT `nuomoja` FOREIGN KEY (`fk_nuomininkasid_is_naudotojas`) REFERENCES `nuomininkas` (`id_is_naudotojas`),
  ADD CONSTRAINT `nuomos_laikotarpis_ibfk_1` FOREIGN KEY (`busena`) REFERENCES `buto_laikotarpio_busena` (`id_buto_laikotarpio_busena`),
  ADD CONSTRAINT `yra_nuomojamas` FOREIGN KEY (`fk_butasid_butas`) REFERENCES `butas` (`id_butas`);

--
-- Constraints for table `privalumas`
--
ALTER TABLE `privalumas`
  ADD CONSTRAINT `turi2` FOREIGN KEY (`fk_butasid_butas`) REFERENCES `butas` (`id_butas`);

--
-- Constraints for table `reitingas`
--
ALTER TABLE `reitingas`
  ADD CONSTRAINT `pateikia2` FOREIGN KEY (`fk_nuomininkasid_is_naudotojas`) REFERENCES `nuomininkas` (`id_is_naudotojas`),
  ADD CONSTRAINT `skiriamas2` FOREIGN KEY (`fk_butasid_butas`) REFERENCES `butas` (`id_butas`);

--
-- Constraints for table `savininkas`
--
ALTER TABLE `savininkas`
  ADD CONSTRAINT `savininkas_ibfk_1` FOREIGN KEY (`id_is_naudotojas`) REFERENCES `is_naudotojas` (`id_is_naudotojas`) ON DELETE CASCADE;

--
-- Constraints for table `skundas`
--
ALTER TABLE `skundas`
  ADD CONSTRAINT `pateikia` FOREIGN KEY (`fk_nuomininkasid_is_naudotojas`) REFERENCES `nuomininkas` (`id_is_naudotojas`),
  ADD CONSTRAINT `skiriamas` FOREIGN KEY (`fk_butasid_butas`) REFERENCES `butas` (`id_butas`);

--
-- Constraints for table `valytojas`
--
ALTER TABLE `valytojas`
  ADD CONSTRAINT `valytojas_ibfk_1` FOREIGN KEY (`id_is_naudotojas`) REFERENCES `is_naudotojas` (`id_is_naudotojas`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
