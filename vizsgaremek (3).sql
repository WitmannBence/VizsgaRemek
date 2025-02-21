-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Feb 21. 12:09
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `vizsgaremek`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `categories`
--

CREATE TABLE `categories` (
  `CategoryID` int(11) NOT NULL,
  `CategoryName` varchar(50) NOT NULL,
  `Description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `privileges`
--

CREATE TABLE `privileges` (
  `id` int(1) NOT NULL,
  `nev` varchar(100) NOT NULL,
  `description` text NOT NULL,
  `szint` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `privileges`
--

INSERT INTO `privileges` (`id`, `nev`, `description`, `szint`) VALUES
(1, 'Felhasználó', 'Alap jogosultságokkal rendelkezik', 1),
(2, 'Admin', 'Teljes hozzáférés', 9),
(3, 'Regisztrált', 'E-mail aktiváció szükséges', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `services`
--

CREATE TABLE `services` (
  `ServiceID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `ServiceName` varchar(100) NOT NULL,
  `TimeCost` decimal(10,2) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `services`
--

INSERT INTO `services` (`ServiceID`, `UserID`, `ServiceName`, `TimeCost`, `Description`, `Category`, `CreatedAt`) VALUES
(14, 6, 'Online Coding Lesson', 10.00, 'Can help in C#, Javascript and more!', 'Programming', '2025-02-21 08:25:21');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `transactions`
--

CREATE TABLE `transactions` (
  `TransactionID` int(11) NOT NULL,
  `SenderID` int(11) NOT NULL,
  `ReceiverID` int(11) NOT NULL,
  `UserServiceID` int(11) NOT NULL,
  `TimeAmount` decimal(10,2) NOT NULL,
  `Description` text DEFAULT NULL,
  `TransactionDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `TransactionCode` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `transactions`
--

INSERT INTO `transactions` (`TransactionID`, `SenderID`, `ReceiverID`, `UserServiceID`, `TimeAmount`, `Description`, `TransactionDate`, `TransactionCode`) VALUES
(1, 1, 6, 10, 10.00, 'string', '2025-02-21 09:11:41', 'string'),
(2, 1, 6, 10, 10.00, 'Service reserved', '2025-02-21 09:19:36', 'B0N2JZ'),
(3, 1, 6, 10, 10.00, 'Service reserved', '2025-02-21 09:32:23', 'GHCV09');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `UserID` int(11) NOT NULL,
  `FelhasznaloNev` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TeljesNev` varchar(60) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `SALT` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `HASH` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Jogosultsag` int(1) NOT NULL,
  `Aktiv` int(1) NOT NULL,
  `RegisztracioDatuma` datetime DEFAULT current_timestamp(),
  `ProfilKepUtvonal` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TimeBalance` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`UserID`, `FelhasznaloNev`, `TeljesNev`, `SALT`, `HASH`, `Email`, `Jogosultsag`, `Aktiv`, `RegisztracioDatuma`, `ProfilKepUtvonal`, `TimeBalance`) VALUES
(1, 'LakatosI', 'Lakatos István', 'zRNnKIdBWprmDl0y7opRWQdvSIDDaCknTrqli8zd0VQ3ilTziKHlAJcUmwR66laF', 'e01b3f5e704025326ed773a974c28694af262f98787441aaef327fc211b949da', 'lakatosi@gmail.com', 9, 1, '2024-11-25 07:33:49', '', 0.00),
(6, 'buda', 'Budaházi Máté', 'lI1SbWrxy0kdcqtJZtKcMcQR7EonQU9NdFtznzXHzG68ynD8s75wGRaQal2z6Sl2', '63aedc15c2abde348633b2d3f058597366bad4713405b12732951a96b8b249b3', 'budahazim@kkszki.hu', 1, 1, '2025-02-21 10:23:21', 'string', 30.00);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user_services`
--

CREATE TABLE `user_services` (
  `id` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `ServiceID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `user_services`
--

INSERT INTO `user_services` (`id`, `UserID`, `ServiceID`) VALUES
(10, 6, 14);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`CategoryID`),
  ADD UNIQUE KEY `CategoryName` (`CategoryName`);

--
-- A tábla indexei `privileges`
--
ALTER TABLE `privileges`
  ADD PRIMARY KEY (`id`),
  ADD KEY `szint` (`szint`);

--
-- A tábla indexei `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`ServiceID`),
  ADD KEY `UserID` (`UserID`);

--
-- A tábla indexei `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`TransactionID`),
  ADD UNIQUE KEY `TransactionCode` (`TransactionCode`),
  ADD KEY `SenderID` (`SenderID`),
  ADD KEY `ReceiverID` (`ReceiverID`),
  ADD KEY `ServiceID` (`UserServiceID`);

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `FelhasznaloNev` (`FelhasznaloNev`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `Jogosultsag` (`Jogosultsag`);

--
-- A tábla indexei `user_services`
--
ALTER TABLE `user_services`
  ADD PRIMARY KEY (`id`),
  ADD KEY `UserId` (`UserID`,`ServiceID`),
  ADD KEY `ServiceID` (`ServiceID`),
  ADD KEY `UserID_2` (`UserID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `categories`
--
ALTER TABLE `categories`
  MODIFY `CategoryID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `privileges`
--
ALTER TABLE `privileges`
  MODIFY `id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `services`
--
ALTER TABLE `services`
  MODIFY `ServiceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT a táblához `transactions`
--
ALTER TABLE `transactions`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `user_services`
--
ALTER TABLE `user_services`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`SenderID`) REFERENCES `user` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`UserServiceID`) REFERENCES `user_services` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`Jogosultsag`) REFERENCES `privileges` (`szint`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `user_services`
--
ALTER TABLE `user_services`
  ADD CONSTRAINT `user_services_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_services_ibfk_2` FOREIGN KEY (`ServiceID`) REFERENCES `services` (`ServiceID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_services_ibfk_3` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
