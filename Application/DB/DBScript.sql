-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema AIBESTDB
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema AIBESTDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `AIBESTDB` DEFAULT CHARACTER SET utf8 ;
USE `AIBESTDB` ;

-- -----------------------------------------------------
-- Table `AIBESTDB`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Users` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(24) NOT NULL,
  `Email` VARCHAR(64) NOT NULL,
  `Password` VARCHAR(24) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Templates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Templates` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `TemplateName` VARCHAR(45) NOT NULL,
  `TemplateFilePath` VARCHAR(1024) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Locations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Locations` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `City` VARCHAR(64) NOT NULL,
  `State` VARCHAR(64) NOT NULL,
  `Country` VARCHAR(64) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Resumes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Resumes` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `UserId` INT NOT NULL,
  `Title` VARCHAR(64) NOT NULL,
  `CreationDate` DATE NOT NULL,
  `LastModifiedDate` DATE NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `UserId_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `UserId`
    FOREIGN KEY (`UserId`)
    REFERENCES `AIBESTDB`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`ResumesTemplates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`ResumesTemplates` (
  `ResumeId` INT NOT NULL,
  `TemplateId` INT NOT NULL,
  PRIMARY KEY (`ResumeId`, `TemplateId`),
  INDEX `TemplateId_idx` (`TemplateId` ASC) VISIBLE,
  CONSTRAINT `TemplateResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TemplateId`
    FOREIGN KEY (`TemplateId`)
    REFERENCES `AIBESTDB`.`Templates` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`ResumesLocations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`ResumesLocations` (
  `ResumeId` INT NOT NULL,
  `LocationId` INT NOT NULL,
  PRIMARY KEY (`ResumeId`, `LocationId`),
  INDEX `LocationId_idx` (`LocationId` ASC) VISIBLE,
  CONSTRAINT `LocationResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `LocationId`
    FOREIGN KEY (`LocationId`)
    REFERENCES `AIBESTDB`.`Locations` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`WorkExperience`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`WorkExperience` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ResumeId` INT NOT NULL,
  `CompanyName` VARCHAR(64) NOT NULL,
  `Position` VARCHAR(64) NOT NULL,
  `StartDate` DATE NOT NULL,
  `EndDate` DATE NULL,
  `Description` BLOB NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `ResumeId_idx` (`ResumeId` ASC) VISIBLE,
  CONSTRAINT `WorkResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`PersonalInfo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`PersonalInfo` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ResumeId` INT NOT NULL,
  `FullName` VARCHAR(64) NOT NULL,
  `Address` VARCHAR(64) NOT NULL,
  `PhoneNumber` VARCHAR(16) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `ResumeId_idx` (`ResumeId` ASC) VISIBLE,
  CONSTRAINT `PersonalInfoResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Education`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Education` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ResumeId` INT NOT NULL,
  `InstituteName` VARCHAR(128) NOT NULL,
  `Degree` VARCHAR(128) NOT NULL,
  `FieldOfStudy` VARCHAR(64) NOT NULL,
  `StartDate` DATE NOT NULL,
  `EndDate` DATE NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `ResumeId_idx` (`ResumeId` ASC) VISIBLE,
  CONSTRAINT `EduResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Certificates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Certificates` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ResumeId` INT NOT NULL,
  `CertificateName` VARCHAR(64) NOT NULL,
  `IssuingOrganization` VARCHAR(64) NOT NULL,
  `IssueDate` DATE NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `ResumeId_idx` (`ResumeId` ASC) VISIBLE,
  CONSTRAINT `CertResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Skills`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Skills` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `SkillName` VARCHAR(64) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`ResumesSkills`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`ResumesSkills` (
  `ResumeId` INT NOT NULL,
  `SkillId` INT NOT NULL,
  PRIMARY KEY (`ResumeId`, `SkillId`),
  INDEX `SkillId_idx` (`SkillId` ASC) VISIBLE,
  CONSTRAINT `SkillResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SkillId`
    FOREIGN KEY (`SkillId`)
    REFERENCES `AIBESTDB`.`Skills` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`Languages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`Languages` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `LanguageName` VARCHAR(45) NOT NULL,
  `ProficiencyLevel` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AIBESTDB`.`ResumesLanguages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AIBESTDB`.`ResumesLanguages` (
  `ResumeId` INT NOT NULL,
  `LanguageId` INT NOT NULL,
  PRIMARY KEY (`ResumeId`, `LanguageId`),
  INDEX `LanguageId_idx` (`LanguageId` ASC) VISIBLE,
  CONSTRAINT `LangResumeId`
    FOREIGN KEY (`ResumeId`)
    REFERENCES `AIBESTDB`.`Resumes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `LanguageId`
    FOREIGN KEY (`LanguageId`)
    REFERENCES `AIBESTDB`.`Languages` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE USER 'AIBESTUser' IDENTIFIED BY 'DevPass';

GRANT SELECT, INSERT, TRIGGER, UPDATE, DELETE ON TABLE `AIBESTDB`.* TO 'AIBESTUser';

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
