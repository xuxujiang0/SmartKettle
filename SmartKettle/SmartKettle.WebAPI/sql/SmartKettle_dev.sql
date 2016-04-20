/*
SQLyog Ultimate v11.27 (32 bit)
MySQL - 5.7.11-log : Database - SmartKettle_dev
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`SmartKettle_dev` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `SmartKettle_dev`;

/*Table structure for table `tb_memberinfo` */

DROP TABLE IF EXISTS `tb_memberinfo`;

CREATE TABLE `tb_memberinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `Account` varchar(50) NOT NULL COMMENT '账号',
  `Passwd` varchar(50) NOT NULL COMMENT '密码',
  `Name` varchar(50) DEFAULT NULL COMMENT '昵称',
  `Age` int(4) DEFAULT NULL COMMENT '年龄',
  `Birthday` date DEFAULT NULL COMMENT '生日',
  `Sex` bit(1) DEFAULT NULL COMMENT 'true:男；false:女',
  `Email` varchar(80) DEFAULT NULL COMMENT '邮箱',
  `Phone` varchar(20) DEFAULT NULL COMMENT '电话',
  `IdCard` varchar(30) DEFAULT NULL COMMENT '身份证',
  `Remark` varchar(200) DEFAULT NULL COMMENT '备注',
  `IsBandQQ` bit(1) DEFAULT NULL COMMENT '是否绑定qq',
  `IsBandWeiXin` bit(1) DEFAULT NULL COMMENT '是否绑定微信',
  `IsBandWeiBo` bit(1) DEFAULT NULL COMMENT '是否绑定新浪微博',
  `CreationDate` datetime DEFAULT NULL COMMENT '创建时间',
  `CreationUser` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `ModifyUser` varchar(50) DEFAULT NULL COMMENT '修改人',
  `ModifyDate` datetime DEFAULT NULL COMMENT '修改时间',
  `Status` bit(1) DEFAULT NULL COMMENT '是否删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Table structure for table `tb_qqinfo` */

DROP TABLE IF EXISTS `tb_qqinfo`;

CREATE TABLE `tb_qqinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Account` varchar(50) NOT NULL,
  `Passwd` varchar(50) NOT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `CreationUser` varchar(50) DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL COMMENT '是否删除',
  `memberid` int(11) NOT NULL COMMENT '对应绑定的会员id',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tb_weixin` */

DROP TABLE IF EXISTS `tb_weixin`;

CREATE TABLE `tb_weixin` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Account` varchar(50) NOT NULL,
  `Passwd` varchar(50) NOT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `CreationUser` varchar(50) DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL,
  `memberid` int(11) NOT NULL COMMENT '对应绑定的会员id',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
