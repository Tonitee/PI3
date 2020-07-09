-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 09-Jul-2020 às 19:57
-- Versão do servidor: 10.4.13-MariaDB
-- versão do PHP: 7.4.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `atividadeaula10`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `plataforma`
--

CREATE TABLE `plataforma` (
  `Id` int(11) NOT NULL,
  `Nome` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `plataforma`
--

INSERT INTO `plataforma` (`Id`, `Nome`) VALUES
(1, 'PC'),
(2, 'PS4'),
(4, 'Nintendo Switch'),
(5, 'PS3'),
(7, 'Xbox 360 Slim');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `Id` int(11) NOT NULL,
  `Nome` longtext DEFAULT NULL,
  `Preco` double NOT NULL,
  `PlataformaId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `Nome`, `Preco`, `PlataformaId`) VALUES
(1, 'Assassin\'s Creed Odissey', 120, 2),
(3, 'Doom Eternal', 75, 1),
(4, 'Tomb Raider', 8, 1),
(6, 'Mario Kart 8 Deluxe', 249, 4),
(8, 'Need For Speed: Payback', 0, 1),
(9, 'Need For Speed: Most Wanted', 0, 1),
(10, 'Injustice: Gods Among Us', 0, 2),
(11, 'Overwatch', 125, 1),
(12, 'Borderlands 2', 26, 1),
(13, 'The Legend of Zelda: Breath of the Wild', 250, 4),
(14, 'Rise of the Tomb Raider', 0, 2),
(15, 'Injustice 2', 80, 2),
(16, 'The Witch 3: Wild Hunt', 27, 1),
(17, 'Street Fighter V', 40, 1),
(19, 'Shadow of Tomb Raider', 60, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200522045751_Inicial', '2.1.14-servicing-32113'),
('20200707200740_AddPlataforma', '2.1.14-servicing-32113');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `plataforma`
--
ALTER TABLE `plataforma`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Produto_PlataformaId` (`PlataformaId`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `plataforma`
--
ALTER TABLE `plataforma`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `produto`
--
ALTER TABLE `produto`
  ADD CONSTRAINT `FK_Produto_Plataforma_PlataformaId` FOREIGN KEY (`PlataformaId`) REFERENCES `plataforma` (`Id`) ON DELETE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
