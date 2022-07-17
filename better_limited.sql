-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2022-06-29 12:51:07
-- 服务器版本： 10.1.30-MariaDB
-- PHP Version: 5.6.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `better_limited`
--

-- --------------------------------------------------------

--
-- 表的结构 `customer`
--

CREATE TABLE `customer` (
  `Customerid` int(11) NOT NULL,
  `customername` varchar(50) NOT NULL,
  `CustomerAddress` varchar(255) DEFAULT NULL,
  `District` varchar(100) DEFAULT NULL,
  `PhoneNumber` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `customer`
--

INSERT INTO `customer` (`Customerid`, `customername`, `CustomerAddress`, `District`, `PhoneNumber`) VALUES
(1, 'Irene', '545 Fei Ngo Shan Road, Wong Tai Sin District, Hong Kong', 'Wong Tai Sin ', 11111111),
(2, 'Isabel', '548 Wu Yuet Street, Tuen Mun, Tuen Mun District, Hong Kong', 'Tuen Mun', 22222221),
(3, 'Hedy', '637 Pak Tin Street, Sham Shui Po District, Hong Ko', 'Sham Shui Po', 33333333),
(4, 'Adam', 'Suite 14a Vista Mt', 'Central', 44444444),
(5, 'Becky', 'Unit 8108/F Nan Fung Centre264-298 abc', 'Sai Kung', 55555551),
(6, 'Carrot', 'Unit 5707 The Center 99 Queens Rd Central Hk', 'Tuen Mun', 66666666),
(7, 'Molly', 'Flat 7 5 / F. Kai Fuk Ind. Centre 1', 'Yung Shue Wan', 77777777),
(8, 'LI Zhi Wei', 'No.77-81', 'Tsuen Wan', 88888888),
(9, 'Rex', '123', 'Central', 99999999),
(10, 'Ires', 'Unit999', 'Eastern', 10101010),
(11, 'Ze', '987', 'Central and Western', 61502323);

-- --------------------------------------------------------

--
-- 表的结构 `defect item`
--

CREATE TABLE `defect item` (
  `defectID` int(11) NOT NULL,
  `itemName` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `itemQuantity` int(11) DEFAULT NULL,
  `returnPrice` double DEFAULT NULL,
  `employeeID` varchar(10) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- 转存表中的数据 `defect item`
--

INSERT INTO `defect item` (`defectID`, `itemName`, `itemQuantity`, `returnPrice`, `employeeID`) VALUES
(22, 'FUJIFILM X-T30 II w/XF18-55mm', 3, 10500, 'C005'),
(23, 'Pavilion 27-ca1006hk', 2, 4000, 'C005');

-- --------------------------------------------------------

--
-- 表的结构 `deliverynote`
--

CREATE TABLE `deliverynote` (
  `deliverynoteid` int(11) NOT NULL,
  `deliveryid` int(11) NOT NULL,
  `deliverysignature` blob
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- 表的结构 `deliveryorder`
--

CREATE TABLE `deliveryorder` (
  `deliveryid` int(11) NOT NULL,
  `docreatedate` date DEFAULT NULL,
  `deliverystatus` varchar(20) DEFAULT NULL,
  `expectdeliverydate` date DEFAULT NULL,
  `timeslot` int(1) DEFAULT NULL,
  `deliverycompleteDate` date DEFAULT NULL,
  `EmpID` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `Customerid` int(11) NOT NULL,
  `InstallationNeed` varchar(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- 转存表中的数据 `deliveryorder`
--

INSERT INTO `deliveryorder` (`deliveryid`, `docreatedate`, `deliverystatus`, `expectdeliverydate`, `timeslot`, `deliverycompleteDate`, `EmpID`, `Customerid`, `InstallationNeed`) VALUES
(1038, '2022-06-28', 'Processing', '2022-06-28', 4, NULL, NULL, 2, 'Y'),
(1039, '2022-06-28', 'Processing', '2022-06-28', 1, NULL, NULL, 4, 'N'),
(1040, '2022-06-28', 'Delivered', '2022-06-28', 2, '2022-06-28', 'C002', 5, 'Y'),
(1041, '2022-06-28', 'Processing', '2022-06-28', 3, NULL, NULL, 8, 'N'),
(1042, '2022-06-28', 'Processing', '2022-06-28', 5, NULL, NULL, 7, 'N');

-- --------------------------------------------------------

--
-- 表的结构 `deliveryorderproduct`
--

CREATE TABLE `deliveryorderproduct` (
  `dopid` int(11) NOT NULL,
  `buyqty` int(11) NOT NULL,
  `deliveryid` int(11) NOT NULL,
  `productid` int(11) NOT NULL,
  `amount` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- 转存表中的数据 `deliveryorderproduct`
--

INSERT INTO `deliveryorderproduct` (`dopid`, `buyqty`, `deliveryid`, `productid`, `amount`) VALUES
(22, 2, 1038, 1, 7000),
(23, 1, 1039, 1, 3500),
(24, 2, 1039, 4, 10000),
(25, 5, 1040, 3, 10000),
(26, 2, 1041, 3, 4000),
(27, 2, 1042, 2, 6000),
(28, 1, 1042, 4, 5000);

-- --------------------------------------------------------

--
-- 表的结构 `deposit receipt`
--

CREATE TABLE `deposit receipt` (
  `Order ID` varchar(10) NOT NULL,
  `itemsID` int(11) NOT NULL,
  `Items Name` varchar(255) DEFAULT NULL,
  `Quantity` int(10) DEFAULT NULL,
  `ItemPrice` double NOT NULL,
  `TotalPrice` double DEFAULT NULL,
  `Deposit Amounts` double DEFAULT NULL,
  `outstanding amounts` double DEFAULT NULL,
  `Created Date` datetime DEFAULT NULL,
  `customerID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- 表的结构 `electronic purchase order`
--

CREATE TABLE `electronic purchase order` (
  `EPOrderID` varchar(20) NOT NULL,
  `TotalPrice` double DEFAULT NULL,
  `EmpID` varchar(255) DEFAULT NULL,
  `Created Date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `electronic purchase order`
--

INSERT INTO `electronic purchase order` (`EPOrderID`, `TotalPrice`, `EmpID`, `Created Date`) VALUES
('EPO001', 30000, 'C009', '2022-05-14 09:00:00');

-- --------------------------------------------------------

--
-- 表的结构 `empolyee`
--

CREATE TABLE `empolyee` (
  `EmpID` varchar(10) NOT NULL,
  `EmpName` varchar(255) NOT NULL,
  `Empdepartment` varchar(255) NOT NULL,
  `account_number` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `security_question_answer` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `empolyee`
--

INSERT INTO `empolyee` (`EmpID`, `EmpName`, `Empdepartment`, `account_number`, `password`, `security_question_answer`) VALUES
('C001', 'Wong', 'Manager', 'c001', 'pw01', 'eat'),
('C002', 'Danielle', 'Delivery Worker', 'c002', 'pw02', 'play'),
('C003', 'Aurora', 'Delivery Worker', 'c003', 'pw03', 'eat'),
('C004', 'Chloe', 'Delivery Worker', 'c004', 'pw04', 'play'),
('C005', 'Gwen', 'Sales', 'c005', 'pw05', 'eat'),
('C006', 'Adolf', 'Sales Manager', 'c006', 'pw06', 'play'),
('C007', 'Borg', 'Accounting', 'c007', 'pw07', 'eat'),
('C008', 'Harriet', 'Accounting', 'c008', 'pw08', 'play'),
('C009', 'Harry', 'Purchase', 'c009', 'pw09', 'eat'),
('C010', 'York', 'Purchase', 'c010', 'pw10', 'play'),
('C011', 'Mia', 'Inventory', 'c011', 'pw11', 'eat'),
('C012', 'Jessica', 'Inventory', 'c012', 'pw12', 'play'),
('C013', 'Emma', 'Technical Support', 'c013', 'pw13', 'eat'),
('C014', 'Ivy', 'Technical Support', 'c014', 'pw14', 'play'),
('C015', 'John', 'Clerk', 'c015', 'pw15', 'eat'),
('c016', 'wooooo', 'admin', 'c016', '??', 'eat'),
('C017', 'Niko', 'Technical Manager', 'c017', 'pw17', 'play');

-- --------------------------------------------------------

--
-- 表的结构 `goods received note`
--

CREATE TABLE `goods received note` (
  `Goods Received Note Number` varchar(10) NOT NULL,
  `Receipt Date` datetime DEFAULT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `ItemType` varchar(255) DEFAULT NULL,
  `ItemBrand` varchar(255) DEFAULT NULL,
  `ItemQuantity` varchar(255) DEFAULT NULL,
  `ItemPrice` varchar(255) DEFAULT NULL,
  `Amounts` double DEFAULT NULL,
  `Buyer Signature` varchar(255) DEFAULT NULL,
  `EPOrderID` varchar(255) DEFAULT NULL,
  `SupplierName` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `goods received note`
--

INSERT INTO `goods received note` (`Goods Received Note Number`, `Receipt Date`, `ItemName`, `ItemType`, `ItemBrand`, `ItemQuantity`, `ItemPrice`, `Amounts`, `Buyer Signature`, `EPOrderID`, `SupplierName`) VALUES
('GRN001', '2022-05-25 09:00:00', 'HUAWEI P50', 'Mobile Phone', 'HUAWEI', '30', '1000', 30000, 'Harry', 'EPO001', 'HUAWEI');

-- --------------------------------------------------------

--
-- 表的结构 `goods returned note`
--

CREATE TABLE `goods returned note` (
  `Goods Returned Note Number` varchar(255) NOT NULL,
  `Company Name` varchar(255) DEFAULT NULL,
  `EmpID` varchar(20) DEFAULT NULL,
  `Returner` varchar(255) DEFAULT NULL,
  `Return Date` datetime DEFAULT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `Amounts` double DEFAULT NULL,
  `item Return Reason` varchar(255) DEFAULT NULL,
  `Amount of Money Returned` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `goods returned note`
--

INSERT INTO `goods returned note` (`Goods Returned Note Number`, `Company Name`, `EmpID`, `Returner`, `Return Date`, `ItemName`, `Amounts`, `item Return Reason`, `Amount of Money Returned`) VALUES
('GRE001', 'Tsuen Wan', 'C005', 'Isabel', '2022-05-23 18:00:00', 'HUAWEI P50', 3000, 'the phone is cannot use', 3000);

-- --------------------------------------------------------

--
-- 表的结构 `installationrequest`
--

CREATE TABLE `installationrequest` (
  `installRequestid` int(11) NOT NULL,
  `installEmpID` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `installDate` date DEFAULT NULL,
  `installComDate` date DEFAULT NULL,
  `installTimeslot` int(1) DEFAULT NULL,
  `installStatus` varchar(30) DEFAULT NULL,
  `installSignImage` blob,
  `deliveryid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- 转存表中的数据 `installationrequest`
--

INSERT INTO `installationrequest` (`installRequestid`, `installEmpID`, `installDate`, `installComDate`, `installTimeslot`, `installStatus`, `installSignImage`, `deliveryid`) VALUES
(4003, NULL, '2022-06-28', NULL, 4, 'Processing', NULL, 1038),
(4004, 'C013', '2022-06-28', '2022-06-28', 2, 'Completed', NULL, 1040);

-- --------------------------------------------------------

--
-- 表的结构 `inventory level`
--

CREATE TABLE `inventory level` (
  `StockID` int(11) NOT NULL,
  `StockName` varchar(255) DEFAULT NULL,
  `StockType` varchar(255) DEFAULT NULL,
  `StockBrand` varchar(255) DEFAULT NULL,
  `StockStatus` varchar(255) DEFAULT NULL,
  `StockQuantity` smallint(6) DEFAULT NULL,
  `StockMaxNumber` smallint(6) DEFAULT NULL,
  `EmpID` varchar(255) DEFAULT NULL,
  `RefillLevel` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `inventory level`
--

INSERT INTO `inventory level` (`StockID`, `StockName`, `StockType`, `StockBrand`, `StockStatus`, `StockQuantity`, `StockMaxNumber`, `EmpID`, `RefillLevel`) VALUES
(1, 'FUJIFILM X-T30 II w/XF18-55mm', 'mirrorless camera', 'FUJIFILM', 'Sufficient', 75, 100, 'C011', 20),
(2, 'HUAWEI P50', 'Mobile Phone', 'HUAWEI', 'Out of stock', 19, 100, 'C012', 20),
(3, 'Pavilion 27-ca1006hk', 'computer', 'Pavilion', 'Sufficient', 40, 80, 'C012', 16),
(4, 'Smeg FAB28 Smeg', 'refrigerator', 'Smeg', 'Sufficient', 9, 40, 'C011', 8),
(5, 'SONA Wb3042 Smeg', 'computer', 'SONA', 'Out of stock', 10, 40, 'C011', 20);

-- --------------------------------------------------------

--
-- 表的结构 `payment`
--

CREATE TABLE `payment` (
  `Order ID` varchar(10) NOT NULL,
  `Payment` varchar(255) DEFAULT NULL,
  `Created Date` datetime DEFAULT NULL,
  `EmpID` varchar(10) DEFAULT NULL,
  `PaymentMethod` varchar(20) NOT NULL,
  `Region` varchar(20) NOT NULL,
  `TotalPrice` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `payment`
--

INSERT INTO `payment` (`Order ID`, `Payment`, `Created Date`, `EmpID`, `PaymentMethod`, `Region`, `TotalPrice`) VALUES
('3', 'Payment Receipt', '2022-06-09 21:11:08', 'C005', 'Alipay', 'Tsuen Wan', 3500),
('4', 'Payment Receipt', '2022-06-19 15:14:20', 'C005', 'Alipay', 'Tsuen Wan', 7000),
('5', 'Payment Receipt', '2022-06-28 21:03:40', 'C005', 'Alipay', 'Tsuen Wan', 7000),
('6', 'Payment Receipt', '2022-06-28 21:03:54', 'C005', 'AlipayHK', 'Kowloon Bay', 3500),
('7', 'Payment Receipt', '2022-06-28 21:04:30', 'C005', 'Alipay', 'Tsuen Wan', 20500),
('8', 'Payment Receipt', '2022-06-28 21:05:08', 'C005', 'Alipay', 'Tsuen Wan', 4000),
('9', 'Payment Receipt', '2022-06-28 21:05:38', 'C005', 'Cash', 'Shen Zhen', 10000);

-- --------------------------------------------------------

--
-- 表的结构 `payment receipt`
--

CREATE TABLE `payment receipt` (
  `Order ID` varchar(10) NOT NULL,
  `itemsID` int(11) NOT NULL,
  `Items Name` varchar(255) DEFAULT NULL,
  `Quantity` int(5) NOT NULL,
  `Item Price` double DEFAULT NULL,
  `Payment amounts` double DEFAULT NULL,
  `Created Date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `payment receipt`
--

INSERT INTO `payment receipt` (`Order ID`, `itemsID`, `Items Name`, `Quantity`, `Item Price`, `Payment amounts`, `Created Date`) VALUES
('3', 1, 'FUJIFILM X-T30 II w/XF18-55mm', 1, 3500, 3500, '2022-06-09 21:11:08'),
('4', 1, 'FUJIFILM X-T30 II w/XF18-55mm', 2, 7000, 7000, '2022-06-19 15:14:20'),
('5', 1, 'FUJIFILM X-T30 II w/XF18-55mm', 2, 7000, 7000, '2022-06-28 21:03:40'),
('6', 1, 'FUJIFILM X-T30 II w/XF18-55mm', 1, 3500, 3500, '2022-06-28 21:03:54'),
('7', 1, 'FUJIFILM X-T30 II w/XF18-55mm', 1, 3500, 20500, '2022-06-28 21:04:30'),
('7', 3, 'Pavilion 27-ca1006hk', 1, 2000, 20500, '2022-06-28 21:04:30'),
('8', 3, 'Pavilion 27-ca1006hk', 2, 4000, 4000, '2022-06-28 21:05:08'),
('7', 4, 'Smeg FAB28 Smeg', 3, 15000, 20500, '2022-06-28 21:04:30'),
('9', 4, 'Smeg FAB28 Smeg', 2, 10000, 10000, '2022-06-28 21:05:38');

-- --------------------------------------------------------

--
-- 表的结构 `product`
--

CREATE TABLE `product` (
  `productid` int(11) NOT NULL,
  `productname` varchar(100) NOT NULL,
  `productType` varchar(30) NOT NULL,
  `productbrand` varchar(255) NOT NULL,
  `productweight` float NOT NULL,
  `productUnitQty` int(11) NOT NULL,
  `productUnitprice` double NOT NULL,
  `StockMaxNumber` int(11) NOT NULL,
  `EmpID` varchar(10) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- 转存表中的数据 `product`
--

INSERT INTO `product` (`productid`, `productname`, `productType`, `productbrand`, `productweight`, `productUnitQty`, `productUnitprice`, `StockMaxNumber`, `EmpID`) VALUES
(1, 'FUJIFILM X-T30 II w/XF18-55mm', 'mirrorless camera', 'FUJIFILM', 5.2, 28, 3500, 50, 'C006'),
(2, 'HUAWEI P50', 'Mobile Phone', 'HUAWEI', 3.1, 0, 3000, 50, 'C006'),
(3, 'Pavilion 27-ca1006hk', 'computer', 'Pavilion', 7.1, 20, 2000, 50, 'C006'),
(4, 'Smeg FAB28 Smeg', 'refrigerator', 'Smeg', 15.3, 5, 5000, 50, 'C006');

-- --------------------------------------------------------

--
-- 表的结构 `purchase order detail`
--

CREATE TABLE `purchase order detail` (
  `EPOrderID` varchar(20) NOT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `ItemType` varchar(255) DEFAULT NULL,
  `ItemBrand` varchar(255) DEFAULT NULL,
  `Supplier` varchar(255) DEFAULT NULL,
  `ItemQuantity` smallint(6) DEFAULT NULL,
  `ItemPrice` double DEFAULT NULL,
  `Amounts` double DEFAULT NULL,
  `Delivery Deadline` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `purchase order detail`
--

INSERT INTO `purchase order detail` (`EPOrderID`, `ItemName`, `ItemType`, `ItemBrand`, `Supplier`, `ItemQuantity`, `ItemPrice`, `Amounts`, `Delivery Deadline`) VALUES
('EPO001', 'HUAWEI P50', 'Mobile Phone', 'HUAWEI', 'HUAWEI', 30, 1000, 30000, '2022-05-24 09:00:00');

-- --------------------------------------------------------

--
-- 表的结构 `re-order requests`
--

CREATE TABLE `re-order requests` (
  `ReOrderID` varchar(20) NOT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `ItemType` varchar(255) DEFAULT NULL,
  `ItemBrand` varchar(255) DEFAULT NULL,
  `ItemQuantity` smallint(6) DEFAULT NULL,
  `EmpID` varchar(255) DEFAULT NULL,
  `Created Date` datetime DEFAULT NULL,
  `Delivery Address` varchar(255) DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  `Amounts` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- 表的结构 `reorderingitem`
--

CREATE TABLE `reorderingitem` (
  `ReOrderID` int(11) NOT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `ItemType` varchar(255) DEFAULT NULL,
  `ItemBrand` varchar(255) DEFAULT NULL,
  `Supplier` varchar(255) DEFAULT NULL,
  `ItemQuantity` smallint(6) DEFAULT NULL,
  `ItemPrice` double DEFAULT NULL,
  `Amounts` double DEFAULT NULL,
  `ReceiveDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `reorderingitem`
--

INSERT INTO `reorderingitem` (`ReOrderID`, `ItemName`, `ItemType`, `ItemBrand`, `Supplier`, `ItemQuantity`, `ItemPrice`, `Amounts`, `ReceiveDate`) VALUES
(1, 'HUAWEI P50', 'Mobile Phone', 'HUAWEI', 'HUAWEI', 30, 1000, 30000, '2022-05-03'),
(2, 'SONA SA70', 'computer', 'SONA', 'SONA', 30, 9999, 299970, '2022-08-24');

-- --------------------------------------------------------

--
-- 表的结构 `replenishment request`
--

CREATE TABLE `replenishment request` (
  `ReplenishmentID` varchar(20) NOT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `ItemType` varchar(255) DEFAULT NULL,
  `ItemBrand` varchar(255) DEFAULT NULL,
  `ItemQuantity` smallint(6) DEFAULT NULL,
  `Store Address` varchar(255) DEFAULT NULL,
  `Created Date` datetime DEFAULT NULL,
  `Delivery Address` varchar(255) DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  `EmpID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `replenishment request`
--

INSERT INTO `replenishment request` (`ReplenishmentID`, `ItemName`, `ItemType`, `ItemBrand`, `ItemQuantity`, `Store Address`, `Created Date`, `Delivery Address`, `Remarks`, `EmpID`) VALUES
('RP001', 'HUAWEI P50', 'Mobile Phone', 'HUAWEI', 15, 'Tsuen Wan', '2022-05-14 09:00:00', 'Kowloon Bay', NULL, 'C011');

-- --------------------------------------------------------

--
-- 表的结构 `supplier`
--

CREATE TABLE `supplier` (
  `SupplierName` varchar(255) NOT NULL,
  `SupplierPhoneNumber` varchar(255) DEFAULT NULL,
  `SupplierEmail` varchar(255) DEFAULT NULL,
  `SupplierAddress` varchar(255) DEFAULT NULL,
  `SupplierOther` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `supplier`
--

INSERT INTO `supplier` (`SupplierName`, `SupplierPhoneNumber`, `SupplierEmail`, `SupplierAddress`, `SupplierOther`) VALUES
('HUAWEI', '45648965', 'bromrwgqxm@iubridge.com', '133 Yuk Sau Street, Happy Valley, Wan Chai District, Hong Kong', 'null'),
('SONA', '23948321', 'sqpueoal@wiadmq.com', '343 Ching Ping Street, World Valley, Wan Chai District, Hong Kong', 'null');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`Customerid`);

--
-- Indexes for table `defect item`
--
ALTER TABLE `defect item`
  ADD PRIMARY KEY (`defectID`),
  ADD KEY `employeeID` (`employeeID`);

--
-- Indexes for table `deliverynote`
--
ALTER TABLE `deliverynote`
  ADD PRIMARY KEY (`deliverynoteid`),
  ADD KEY `deliveryid` (`deliveryid`);

--
-- Indexes for table `deliveryorder`
--
ALTER TABLE `deliveryorder`
  ADD PRIMARY KEY (`deliveryid`),
  ADD KEY `EmpID` (`EmpID`),
  ADD KEY `Customerid` (`Customerid`);

--
-- Indexes for table `deliveryorderproduct`
--
ALTER TABLE `deliveryorderproduct`
  ADD PRIMARY KEY (`dopid`),
  ADD KEY `deliveryid` (`deliveryid`),
  ADD KEY `productid` (`productid`);

--
-- Indexes for table `deposit receipt`
--
ALTER TABLE `deposit receipt`
  ADD PRIMARY KEY (`itemsID`,`Order ID`),
  ADD KEY `Order ID` (`Order ID`),
  ADD KEY `customerID` (`customerID`);

--
-- Indexes for table `electronic purchase order`
--
ALTER TABLE `electronic purchase order`
  ADD PRIMARY KEY (`EPOrderID`),
  ADD KEY `EmpID` (`EmpID`);

--
-- Indexes for table `empolyee`
--
ALTER TABLE `empolyee`
  ADD PRIMARY KEY (`EmpID`);

--
-- Indexes for table `goods received note`
--
ALTER TABLE `goods received note`
  ADD PRIMARY KEY (`Goods Received Note Number`),
  ADD KEY `EPOrderID` (`EPOrderID`),
  ADD KEY `SupplierName` (`SupplierName`);

--
-- Indexes for table `goods returned note`
--
ALTER TABLE `goods returned note`
  ADD PRIMARY KEY (`Goods Returned Note Number`),
  ADD KEY `EmpID` (`EmpID`);

--
-- Indexes for table `installationrequest`
--
ALTER TABLE `installationrequest`
  ADD PRIMARY KEY (`installRequestid`),
  ADD KEY `deliveryid` (`deliveryid`),
  ADD KEY `installEmpID` (`installEmpID`) USING BTREE;

--
-- Indexes for table `inventory level`
--
ALTER TABLE `inventory level`
  ADD PRIMARY KEY (`StockID`),
  ADD KEY `inventory level_ibfk_1` (`EmpID`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`Order ID`),
  ADD UNIQUE KEY `Order ID` (`Order ID`),
  ADD KEY `EmpID` (`EmpID`);

--
-- Indexes for table `payment receipt`
--
ALTER TABLE `payment receipt`
  ADD PRIMARY KEY (`itemsID`,`Order ID`),
  ADD KEY `Order ID` (`Order ID`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`productid`),
  ADD KEY `EmpID` (`EmpID`);

--
-- Indexes for table `purchase order detail`
--
ALTER TABLE `purchase order detail`
  ADD PRIMARY KEY (`EPOrderID`),
  ADD KEY `purchase order detail_ibfk_1` (`Supplier`);

--
-- Indexes for table `re-order requests`
--
ALTER TABLE `re-order requests`
  ADD PRIMARY KEY (`ReOrderID`),
  ADD KEY `EmpID` (`EmpID`);

--
-- Indexes for table `reorderingitem`
--
ALTER TABLE `reorderingitem`
  ADD PRIMARY KEY (`ReOrderID`),
  ADD KEY `reorderingitem_ibfk_1` (`Supplier`);

--
-- Indexes for table `replenishment request`
--
ALTER TABLE `replenishment request`
  ADD PRIMARY KEY (`ReplenishmentID`),
  ADD KEY `EmpID` (`EmpID`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`SupplierName`);

--
-- 在导出的表使用AUTO_INCREMENT
--

--
-- 使用表AUTO_INCREMENT `customer`
--
ALTER TABLE `customer`
  MODIFY `Customerid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- 使用表AUTO_INCREMENT `defect item`
--
ALTER TABLE `defect item`
  MODIFY `defectID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- 使用表AUTO_INCREMENT `deliverynote`
--
ALTER TABLE `deliverynote`
  MODIFY `deliverynoteid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- 使用表AUTO_INCREMENT `deliveryorder`
--
ALTER TABLE `deliveryorder`
  MODIFY `deliveryid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1043;

--
-- 使用表AUTO_INCREMENT `deliveryorderproduct`
--
ALTER TABLE `deliveryorderproduct`
  MODIFY `dopid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- 使用表AUTO_INCREMENT `installationrequest`
--
ALTER TABLE `installationrequest`
  MODIFY `installRequestid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4005;

--
-- 使用表AUTO_INCREMENT `inventory level`
--
ALTER TABLE `inventory level`
  MODIFY `StockID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- 使用表AUTO_INCREMENT `product`
--
ALTER TABLE `product`
  MODIFY `productid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- 使用表AUTO_INCREMENT `reorderingitem`
--
ALTER TABLE `reorderingitem`
  MODIFY `ReOrderID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- 限制导出的表
--

--
-- 限制表 `defect item`
--
ALTER TABLE `defect item`
  ADD CONSTRAINT `defect item_ibfk_1` FOREIGN KEY (`employeeID`) REFERENCES `empolyee` (`EmpID`);

--
-- 限制表 `deliverynote`
--
ALTER TABLE `deliverynote`
  ADD CONSTRAINT `deliverynote_ibfk_1` FOREIGN KEY (`deliveryid`) REFERENCES `deliveryorder` (`deliveryid`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- 限制表 `deliveryorder`
--
ALTER TABLE `deliveryorder`
  ADD CONSTRAINT `deliveryorder_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`),
  ADD CONSTRAINT `deliveryorder_ibfk_2` FOREIGN KEY (`Customerid`) REFERENCES `customer` (`Customerid`);

--
-- 限制表 `deliveryorderproduct`
--
ALTER TABLE `deliveryorderproduct`
  ADD CONSTRAINT `deliveryorderproduct_ibfk_1` FOREIGN KEY (`deliveryid`) REFERENCES `deliveryorder` (`deliveryid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `deliveryorderproduct_ibfk_2` FOREIGN KEY (`productid`) REFERENCES `product` (`productid`);

--
-- 限制表 `deposit receipt`
--
ALTER TABLE `deposit receipt`
  ADD CONSTRAINT `deposit receipt_ibfk_2` FOREIGN KEY (`itemsID`) REFERENCES `product` (`productid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `deposit receipt_ibfk_3` FOREIGN KEY (`Order ID`) REFERENCES `payment` (`Order ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `deposit receipt_ibfk_4` FOREIGN KEY (`customerID`) REFERENCES `customer` (`Customerid`);

--
-- 限制表 `electronic purchase order`
--
ALTER TABLE `electronic purchase order`
  ADD CONSTRAINT `electronic purchase order_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- 限制表 `goods received note`
--
ALTER TABLE `goods received note`
  ADD CONSTRAINT `goods received note_ibfk_1` FOREIGN KEY (`EPOrderID`) REFERENCES `electronic purchase order` (`EPOrderID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `goods received note_ibfk_2` FOREIGN KEY (`SupplierName`) REFERENCES `supplier` (`SupplierName`);

--
-- 限制表 `goods returned note`
--
ALTER TABLE `goods returned note`
  ADD CONSTRAINT `goods returned note_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- 限制表 `installationrequest`
--
ALTER TABLE `installationrequest`
  ADD CONSTRAINT `installationrequest_ibfk_1` FOREIGN KEY (`deliveryid`) REFERENCES `deliveryorder` (`deliveryid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `installationrequest_ibfk_2` FOREIGN KEY (`installEmpID`) REFERENCES `empolyee` (`EmpID`);

--
-- 限制表 `inventory level`
--
ALTER TABLE `inventory level`
  ADD CONSTRAINT `inventory level_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`);

--
-- 限制表 `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`);

--
-- 限制表 `payment receipt`
--
ALTER TABLE `payment receipt`
  ADD CONSTRAINT `payment receipt_ibfk_2` FOREIGN KEY (`itemsID`) REFERENCES `product` (`productid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `payment receipt_ibfk_3` FOREIGN KEY (`Order ID`) REFERENCES `payment` (`Order ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- 限制表 `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`);

--
-- 限制表 `purchase order detail`
--
ALTER TABLE `purchase order detail`
  ADD CONSTRAINT `purchase order detail_ibfk_1` FOREIGN KEY (`Supplier`) REFERENCES `supplier` (`SupplierName`),
  ADD CONSTRAINT `purchase order detail_ibfk_2` FOREIGN KEY (`EPOrderID`) REFERENCES `electronic purchase order` (`EPOrderID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- 限制表 `re-order requests`
--
ALTER TABLE `re-order requests`
  ADD CONSTRAINT `re-order requests_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`);

--
-- 限制表 `reorderingitem`
--
ALTER TABLE `reorderingitem`
  ADD CONSTRAINT `reorderingitem_ibfk_1` FOREIGN KEY (`Supplier`) REFERENCES `supplier` (`SupplierName`);

--
-- 限制表 `replenishment request`
--
ALTER TABLE `replenishment request`
  ADD CONSTRAINT `replenishment request_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `empolyee` (`EmpID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
