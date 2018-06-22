-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema CS358
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema CS358
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `CS358` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `CS358` ;

-- -----------------------------------------------------
-- Table `CS358`.`Location`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CS358`.`Location` (
  `L_Zip` INT(6) NOT NULL COMMENT '',
  `L_State` VARCHAR(20) NOT NULL COMMENT '',
  `L_City` VARCHAR(30) NOT NULL COMMENT '',
  PRIMARY KEY (`L_Zip`)  COMMENT '',
  UNIQUE INDEX `L_Zip_UNIQUE` (`L_Zip` ASC)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CS358`.`Customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CS358`.`Customer` (
  `C_ID` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `C_FName` VARCHAR(45) NOT NULL COMMENT '',
  `C_LName` VARCHAR(45) NOT NULL COMMENT '',
  `L_Zip` INT(6) NOT NULL COMMENT '',
  `C_Address` VARCHAR(45) NOT NULL COMMENT '',
  `C_Phone` BIGINT NULL COMMENT '',
  `C_Email` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`C_ID`)  COMMENT '',
  INDEX `L_Zip_idx` (`L_Zip` ASC)  COMMENT '',
  UNIQUE INDEX `C_ID_UNIQUE` (`C_ID` ASC)  COMMENT '',
  CONSTRAINT `L_Zip`
    FOREIGN KEY (`L_Zip`)
    REFERENCES `CS358`.`Location` (`L_Zip`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CS358`.`Transaction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CS358`.`Transaction` (
  `T_ID` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `C_ID` INT NOT NULL COMMENT '',
  `T_Date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '',
  `T_BuySell` TINYINT(1) NOT NULL COMMENT '',
  PRIMARY KEY (`T_ID`)  COMMENT '',
  INDEX `C_ID_idx` (`C_ID` ASC)  COMMENT '',
  UNIQUE INDEX `T_ID_UNIQUE` (`T_ID` ASC)  COMMENT '',
  CONSTRAINT `C_ID`
    FOREIGN KEY (`C_ID`)
    REFERENCES `CS358`.`Customer` (`C_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CS358`.`Item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CS358`.`Item` (
  `L_ID` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `T_ID` INT NOT NULL COMMENT '',
  `I_Name` VARCHAR(45) NOT NULL COMMENT '',
  `I_Quantity` DOUBLE NOT NULL COMMENT '',
  `I_Price` DOUBLE NOT NULL COMMENT '',
  `I_CarPlate` VARCHAR(45) NULL COMMENT '',
  `I_CarColor` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`L_ID`)  COMMENT '',
  INDEX `T_ID_idx` (`T_ID` ASC)  COMMENT '',
  UNIQUE INDEX `L_ID_UNIQUE` (`L_ID` ASC)  COMMENT '',
  CONSTRAINT `T_ID`
    FOREIGN KEY (`T_ID`)
    REFERENCES `CS358`.`Transaction` (`T_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE USER 'newUser' IDENTIFIED BY 'lamepasswod';

GRANT ALL ON `CS358`.* TO 'newUser';
GRANT SELECT, INSERT, TRIGGER ON TABLE `CS358`.* TO 'newUser';
GRANT SELECT, INSERT, TRIGGER, UPDATE, DELETE ON TABLE `CS358`.* TO 'newUser';

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
