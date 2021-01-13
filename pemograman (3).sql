-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 10 Jan 2021 pada 15.43
-- Versi server: 10.4.11-MariaDB
-- Versi PHP: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pemograman`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `barang`
--

CREATE TABLE `barang` (
  `ID_Barang` int(50) NOT NULL,
  `Nama_Barang` varchar(30) NOT NULL,
  `ID_Kategori` int(50) NOT NULL,
  `ID_Faktur_Keluar` int(30) NOT NULL,
  `ID_Rak` int(50) NOT NULL,
  `Satuan` varchar(20) NOT NULL,
  `Stock` int(30) NOT NULL,
  `Tanggal` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barang`
--

INSERT INTO `barang` (`ID_Barang`, `Nama_Barang`, `ID_Kategori`, `ID_Faktur_Keluar`, `ID_Rak`, `Satuan`, `Stock`, `Tanggal`) VALUES
(1, 'Salad Dressing', 2, 9, 2, 'Kilogram', 95, '2019-07-17 10:39:00'),
(3, 'Beef - Top Butt Aaa', 4, 9, 9, 'Biji', 172, '2020-08-09 00:52:22'),
(4, 'Muffin Mix - Corn Harvest', 5, 6, 3, 'Lusin', 183, '2020-06-17 06:28:03'),
(5, 'Sultanas', 2, 4, 7, 'Biji', 314, '2020-03-13 13:30:24'),
(6, 'Potatoes - Pei 10 Oz', 4, 5, 3, 'Kilogram', 159, '2020-06-03 09:30:54'),
(7, 'Wine - Sherry Dry Sack, Willia', 4, 3, 5, 'Biji', 29, '2019-01-26 13:08:20'),
(8, 'Sugar - Splenda Sweetener', 1, 10, 5, 'Biji', 14, '2020-05-29 11:36:41'),
(9, 'Soup - Beef, Base Mix', 7, 2, 1, 'Dim', 23, '2020-10-19 12:28:52'),
(10, 'Buffalo - Tenderloin', 3, 4, 1, 'Biji', 114, '2020-01-09 00:40:43'),
(11, 'Pepper - Red Bell', 4, 2, 2, 'Dim', 35, '2020-11-23 23:07:29'),
(12, 'Parasol Pick Stir Stick', 1, 10, 6, 'Lusin', 285, '2020-10-13 06:38:14'),
(13, 'Aspic - Amber', 3, 3, 5, 'Kilogram', 112, '2020-08-08 02:36:18'),
(14, 'Beans - Butter Lrg Lima', 6, 10, 9, 'Dim', 112, '2019-09-27 10:40:20'),
(15, 'Compound - Rum', 5, 1, 4, 'Biji', 311, '2019-01-20 19:27:31'),
(16, 'Coffee - Frthy Coffee Crisp', 1, 4, 4, 'Lusin', 153, '2019-04-09 17:39:21'),
(17, 'Containter - 3oz Microwave Rec', 3, 6, 6, 'Kilogram', 338, '2020-02-14 23:42:44'),
(18, 'Mop Head - Cotton, 24 Oz', 1, 5, 5, 'Lusin', 312, '2020-04-18 01:27:34'),
(19, 'Grenadillo', 2, 3, 1, 'Dim', 223, '2020-07-29 17:41:03'),
(20, 'Cheese - Asiago', 6, 7, 4, 'Kilogram', 369, '2019-12-22 14:25:14'),
(21, 'Wine - Prosecco Valdobienne', 6, 8, 5, 'Kilogram', 353, '2019-01-16 03:58:55'),
(22, 'Shallots', 3, 10, 9, 'Kilogram', 151, '2019-04-04 07:37:45'),
(23, 'Wine - Jafflin Bourgongone', 6, 6, 3, 'Lusin', 176, '2020-10-17 23:34:34'),
(24, 'Lid Tray - 12in Dome', 2, 8, 3, 'Kilogram', 294, '2020-03-15 17:26:27'),
(25, 'Cod - Fillets', 3, 2, 9, 'Lusin', 51, '2019-07-19 01:16:00'),
(26, 'Shallots', 2, 3, 5, 'Lusin', 158, '2019-12-08 04:57:55'),
(27, 'Sprite - 355 Ml', 5, 9, 7, 'Biji', 162, '2019-01-23 10:27:03'),
(28, 'Olives - Stuffed', 1, 10, 1, 'Biji', 90, '2019-03-01 18:49:05'),
(29, 'Sorrel - Fresh', 3, 1, 2, 'Biji', 139, '2020-08-01 16:19:28'),
(30, 'Truffle Paste', 1, 7, 9, 'Dim', 281, '2019-01-24 01:23:34'),
(33, 'Laptop', 6, 10, 3, 'Pcs', 10, '1/9/2021 11:09:50 AM'),
(34, 'handphone', 3, 10, 2, 'Pcs', 10, '1/9/2021 11:33:52 AM');

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangkeluar`
--

CREATE TABLE `barangkeluar` (
  `ID_Faktur_Keluar` int(30) NOT NULL,
  `Tanggal` datetime NOT NULL,
  `ID_Petugas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangkeluar`
--

INSERT INTO `barangkeluar` (`ID_Faktur_Keluar`, `Tanggal`, `ID_Petugas`) VALUES
(1, '2020-02-02 23:43:35', 7),
(2, '2019-02-03 23:29:24', 10),
(3, '2019-09-01 10:04:32', 9),
(4, '2019-09-11 05:49:25', 3),
(5, '2020-07-07 19:23:05', 10),
(6, '2019-11-18 18:33:12', 3),
(7, '2020-04-29 14:14:04', 5),
(8, '2019-11-21 01:28:36', 8),
(9, '2019-03-08 09:48:58', 1),
(10, '2020-11-11 04:59:13', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangmasuk`
--

CREATE TABLE `barangmasuk` (
  `ID_Faktur` int(30) NOT NULL,
  `Tanggal` datetime(6) NOT NULL,
  `ID_Petugas` int(10) NOT NULL,
  `ID_Supplier` int(20) NOT NULL,
  `ID_Kategori` int(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangmasuk`
--

INSERT INTO `barangmasuk` (`ID_Faktur`, `Tanggal`, `ID_Petugas`, `ID_Supplier`, `ID_Kategori`) VALUES
(1, '2020-06-21 23:32:50.000000', 10, 5, 5),
(2, '2020-08-03 12:57:54.000000', 6, 4, 1),
(3, '2020-10-31 10:59:10.000000', 5, 1, 1),
(4, '2020-07-29 23:39:38.000000', 10, 2, 1),
(5, '2020-02-15 20:00:12.000000', 2, 7, 7),
(6, '2019-01-30 18:41:53.000000', 9, 9, 7),
(7, '2019-02-18 16:13:54.000000', 4, 8, 1),
(8, '2020-02-17 06:48:22.000000', 3, 3, 8),
(9, '2019-08-14 06:52:34.000000', 6, 9, 6),
(10, '2020-02-02 19:13:38.000000', 9, 9, 7);

-- --------------------------------------------------------

--
-- Struktur dari tabel `kategori`
--

CREATE TABLE `kategori` (
  `ID_Kategori` int(50) NOT NULL,
  `Nama_Kategori` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `kategori`
--

INSERT INTO `kategori` (`ID_Kategori`, `Nama_Kategori`) VALUES
(1, 'bahan baku'),
(2, 'barang setengah jadi'),
(3, 'pemeliharaan'),
(4, 'perbaikan'),
(5, 'operasi'),
(6, 'barang jadi'),
(7, 'pengamanan'),
(8, 'antisipasi');

-- --------------------------------------------------------

--
-- Struktur dari tabel `petugas`
--

CREATE TABLE `petugas` (
  `ID_Petugas` int(10) NOT NULL,
  `Nama_Petugas` text NOT NULL,
  `Password_Petugas` varchar(10) NOT NULL,
  `Status_Petugas` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `petugas`
--

INSERT INTO `petugas` (`ID_Petugas`, `Nama_Petugas`, `Password_Petugas`, `Status_Petugas`) VALUES
(1, 'Amalle', 'amoynham0', 'petugas'),
(2, 'Viva', 'vclissett1', 'petugas'),
(3, 'Marylee', 'mdy2', 'petugas'),
(4, 'Perceval', 'panster3', 'petugas'),
(5, 'Steve', 'scornely4', 'petugas'),
(6, 'Filia', 'fdionisio5', 'petugas'),
(7, 'Birgitta', 'bkalb6', 'petugas'),
(8, 'Lisha', 'lblesing7', 'petugas'),
(9, 'Brigit', 'bholehouse', 'petugas'),
(10, 'Cord', 'cbonfield9', 'petugas'),
(1004, 'fliw', 'fliw', 'petugas'),
(1016, 'p', 'p', 'petugas'),
(1017, 'pemograman', 'pemograman', 'petugas'),
(1018, 'rafly', 'rafly', 'petugas');

-- --------------------------------------------------------

--
-- Struktur dari tabel `rak`
--

CREATE TABLE `rak` (
  `ID_Rak` int(20) NOT NULL,
  `Nama_Rak` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `rak`
--

INSERT INTO `rak` (`ID_Rak`, `Nama_Rak`) VALUES
(1, 'Woods'),
(2, 'Capital Goods'),
(3, 'Finance'),
(4, 'Consumer Services'),
(5, 'Metal'),
(6, 'Technology'),
(7, 'Public Utilities'),
(8, 'Consumer Utilities'),
(9, 'Public Rak'),
(10, 'Goods');

-- --------------------------------------------------------

--
-- Struktur dari tabel `stockopname`
--

CREATE TABLE `stockopname` (
  `ID_Transaksi` int(20) NOT NULL,
  `ID_Faktur` int(30) NOT NULL,
  `Tanggal` datetime(6) NOT NULL,
  `ID_Petugas` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `stockopname`
--

INSERT INTO `stockopname` (`ID_Transaksi`, `ID_Faktur`, `Tanggal`, `ID_Petugas`) VALUES
(1, 3, '2020-02-25 11:55:31.000000', 7),
(2, 2, '2020-10-19 04:22:18.000000', 9),
(3, 8, '2020-10-06 05:00:44.000000', 9),
(4, 1, '2020-06-09 20:49:12.000000', 2),
(5, 2, '2020-04-04 20:19:52.000000', 4),
(6, 9, '2020-04-02 11:19:17.000000', 7),
(7, 5, '2020-09-10 19:13:46.000000', 7),
(8, 1, '2020-03-19 00:42:26.000000', 7),
(9, 8, '2020-09-15 09:19:41.000000', 6),
(10, 3, '2020-10-31 21:12:51.000000', 3);

-- --------------------------------------------------------

--
-- Struktur dari tabel `stockopnamebarang`
--

CREATE TABLE `stockopnamebarang` (
  `ID_Transaksi` int(20) NOT NULL,
  `ID_Barang` int(20) NOT NULL,
  `ID_Faktur` int(30) NOT NULL,
  `Jumlah` int(20) NOT NULL,
  `Keterangan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `stockopnamebarang`
--

INSERT INTO `stockopnamebarang` (`ID_Transaksi`, `ID_Barang`, `ID_Faktur`, `Jumlah`, `Keterangan`) VALUES
(2, 12, 10, 67, 'Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.\r\n\r\nNam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.\r\n\r\nCurabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.'),
(9, 1, 1, 124, 'Phasellus in felis. Donec semper sapien a libero. Nam dui.\r\n\r\nProin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.'),
(10, 24, 10, 158, 'In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.\r\n\r\nNulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.\r\n\r\nCras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.'),
(10, 1, 9, 188, 'Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.'),
(8, 13, 1, 79, 'Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.\r\n\r\nMorbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.\r\n\r\nFusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.'),
(4, 16, 2, 199, 'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.'),
(5, 19, 3, 156, 'Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.'),
(10, 3, 4, 98, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.'),
(4, 9, 2, 120, 'In congue. Etiam justo. Etiam pretium iaculis justo.\r\n\r\nIn hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.\r\n\r\nNulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.'),
(5, 3, 5, 49, 'Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.\r\n\r\nIn sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\r\n\r\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.');

-- --------------------------------------------------------

--
-- Struktur dari tabel `supplier`
--

CREATE TABLE `supplier` (
  `ID_Supplier` int(20) NOT NULL,
  `Nama_Supplier` text NOT NULL,
  `Alamat_Supplier` varchar(25) NOT NULL,
  `No_Telpon` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `supplier`
--

INSERT INTO `supplier` (`ID_Supplier`, `Nama_Supplier`, `Alamat_Supplier`, `No_Telpon`) VALUES
(1, 'VonRueden-Paucek', '1905 Di Loreto Junction', '+48-847-576-0032'),
(2, 'Kautzer and Sons', '3134 Fuller Alley', '+55-656-249-6525'),
(3, 'Hammes-Conroy', '2393 Lyons Crossing', '+261-215-294-3894'),
(4, 'Beer, Dooley and Lockman', '127 Transport Point', '+7-526-416-7939'),
(5, 'Bayer Group', '596 Hintze Court', '+7-363-404-9190'),
(6, 'Lebsack-Jacobson', '8 Cardinal Court', '+33-580-101-6669'),
(7, 'Lockman-Witting', '8190 Express Hill', '+58-253-738-5004'),
(8, 'Huels-Hilll', '574 Moose Plaza', '+591-112-595-2812'),
(9, 'Bartell Inc', '39 Merchant Drive', '+30-358-371-4631'),
(10, 'Klocko Group', '9393 Oneill Crossing', '+62-489-664-6995');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`ID_Barang`),
  ADD KEY `RelasiRak` (`ID_Rak`),
  ADD KEY `RelasiKategori` (`ID_Kategori`),
  ADD KEY `RelasiFaktur2` (`ID_Faktur_Keluar`);

--
-- Indeks untuk tabel `barangkeluar`
--
ALTER TABLE `barangkeluar`
  ADD PRIMARY KEY (`ID_Faktur_Keluar`),
  ADD KEY `RelasiPetugas2` (`ID_Petugas`);

--
-- Indeks untuk tabel `barangmasuk`
--
ALTER TABLE `barangmasuk`
  ADD PRIMARY KEY (`ID_Faktur`),
  ADD KEY `RelasiKategori2` (`ID_Kategori`),
  ADD KEY `RelasiSupplierBarang` (`ID_Supplier`),
  ADD KEY `RelasiPetugasBarangMasuk` (`ID_Petugas`);

--
-- Indeks untuk tabel `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`ID_Kategori`);

--
-- Indeks untuk tabel `petugas`
--
ALTER TABLE `petugas`
  ADD PRIMARY KEY (`ID_Petugas`);

--
-- Indeks untuk tabel `rak`
--
ALTER TABLE `rak`
  ADD PRIMARY KEY (`ID_Rak`);

--
-- Indeks untuk tabel `stockopname`
--
ALTER TABLE `stockopname`
  ADD PRIMARY KEY (`ID_Transaksi`),
  ADD KEY `RelasiPetugas` (`ID_Petugas`),
  ADD KEY `RelasiFaktur` (`ID_Faktur`);

--
-- Indeks untuk tabel `stockopnamebarang`
--
ALTER TABLE `stockopnamebarang`
  ADD KEY `RelasiTransaksi` (`ID_Transaksi`),
  ADD KEY `RelasiBarangStock` (`ID_Barang`),
  ADD KEY `RelasiFakturStock` (`ID_Faktur`);

--
-- Indeks untuk tabel `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`ID_Supplier`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `barang`
--
ALTER TABLE `barang`
  MODIFY `ID_Barang` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT untuk tabel `kategori`
--
ALTER TABLE `kategori`
  MODIFY `ID_Kategori` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT untuk tabel `petugas`
--
ALTER TABLE `petugas`
  MODIFY `ID_Petugas` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1019;

--
-- AUTO_INCREMENT untuk tabel `rak`
--
ALTER TABLE `rak`
  MODIFY `ID_Rak` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT untuk tabel `stockopname`
--
ALTER TABLE `stockopname`
  MODIFY `ID_Transaksi` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT untuk tabel `supplier`
--
ALTER TABLE `supplier`
  MODIFY `ID_Supplier` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `barang`
--
ALTER TABLE `barang`
  ADD CONSTRAINT `RelasiFaktur2` FOREIGN KEY (`ID_Faktur_Keluar`) REFERENCES `barangkeluar` (`ID_Faktur_Keluar`),
  ADD CONSTRAINT `RelasiKategori` FOREIGN KEY (`ID_Kategori`) REFERENCES `kategori` (`ID_Kategori`),
  ADD CONSTRAINT `RelasiRak` FOREIGN KEY (`ID_Rak`) REFERENCES `rak` (`ID_Rak`);

--
-- Ketidakleluasaan untuk tabel `barangkeluar`
--
ALTER TABLE `barangkeluar`
  ADD CONSTRAINT `RelasiPetugas2` FOREIGN KEY (`ID_Petugas`) REFERENCES `petugas` (`ID_Petugas`);

--
-- Ketidakleluasaan untuk tabel `barangmasuk`
--
ALTER TABLE `barangmasuk`
  ADD CONSTRAINT `RelasiKategoriBarangMasuk` FOREIGN KEY (`ID_Kategori`) REFERENCES `kategori` (`ID_Kategori`),
  ADD CONSTRAINT `RelasiPetugasBarangMasuk` FOREIGN KEY (`ID_Petugas`) REFERENCES `petugas` (`ID_Petugas`),
  ADD CONSTRAINT `RelasiSupplierBarang` FOREIGN KEY (`ID_Supplier`) REFERENCES `supplier` (`ID_Supplier`);

--
-- Ketidakleluasaan untuk tabel `stockopname`
--
ALTER TABLE `stockopname`
  ADD CONSTRAINT `RelasiFaktur` FOREIGN KEY (`ID_Faktur`) REFERENCES `barangmasuk` (`ID_Faktur`),
  ADD CONSTRAINT `RelasiPetugas` FOREIGN KEY (`ID_Petugas`) REFERENCES `petugas` (`ID_Petugas`);

--
-- Ketidakleluasaan untuk tabel `stockopnamebarang`
--
ALTER TABLE `stockopnamebarang`
  ADD CONSTRAINT `RelasiBarangStock` FOREIGN KEY (`ID_Barang`) REFERENCES `barang` (`ID_Barang`),
  ADD CONSTRAINT `RelasiFakturStock` FOREIGN KEY (`ID_Faktur`) REFERENCES `barangmasuk` (`ID_Faktur`),
  ADD CONSTRAINT `RelasiTransaksi` FOREIGN KEY (`ID_Transaksi`) REFERENCES `stockopname` (`ID_Transaksi`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
