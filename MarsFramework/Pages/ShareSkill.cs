﻿//using AutoItX3Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
using MarsFramework.Config;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static NUnit.Core.NUnitFramework;
namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        [Obsolete]
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Thursday Checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input")]
        private IWebElement Thurs { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Thursday Starttime checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input")]
        private IWebElement ThrusStartTime { get; set; }

        //Thursday Endtime button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input")]
        private IWebElement ThrusEndTime { get; set; }
        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on WorkSample upload
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }
        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }
        //Shareskill popuperrormessage
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Popuperror { get; set; }

        //Delete tag
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span/a")]
        private IWebElement RemoveTag { get; set; }

        //Delete the skill-Exchange
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/span/a")]
        private IWebElement RemoveSkillExchageTag { get; set; }


        internal void EnterShareSkill()
        {
            //Click shareskill button
            Thread.Sleep(2000);
            ShareSkillButton.Click();

            //Populating the exceldata
            Thread.Sleep(2000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //reading the values from excel
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //click on category and subcategory
            CategoryDropDown.Click();
            SelectElement categoryselect = new SelectElement(CategoryDropDown);
            categoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            SubCategoryDropDown.Click();
            SelectElement subcategoryselect = new SelectElement(SubCategoryDropDown);
            subcategoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Adding tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //reading data for startdate and enddate

            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Click on the day
            string day = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            if (day == "Thurs")
            {
                Thurs.Click();
            }

            //StartTime and End time for thrusday
            ThrusStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            ThrusEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //WorkSample Upload
            //WorkSample.Click();
            //AutoItX3 autoIt = new AutoItX3();
            //autoIt.WinActivate("Open");
            //Thread.Sleep(1000);
            //autoIt.Send(Base.FilePath);
            //Thread.Sleep(2000);
            //autoIt.Send("{ENTER}");


            Thread.Sleep(1000);

            Save.Click();

            //Checking for shareskill updatation successfull            
            string error = Popuperror.Text;
            if (error == "Please complete the form correctly.")
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine("ShareSkill Saved");
            }
        }

        internal void EditShareSkill()
        {
            //Populating the exceldata
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");
            Thread.Sleep(3000);

            //Clearing the textbox
            Title.Clear();
            Description.Clear();

            //reading the values from excel
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //click on category and subcategory
            CategoryDropDown.Click();
            SelectElement categoryselect = new SelectElement(CategoryDropDown);
            categoryselect.SelectByText("Programming & Tech");
            SubCategoryDropDown.Click();
            SelectElement subcategoryselect = new SelectElement(SubCategoryDropDown);
            subcategoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Removing Existing tags
            RemoveTag.Click();

            //Adding tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //reading data for startdate and enddate
            GlobalDefinitions.wait(4);
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Click on the day
            string day = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            if (day == "Thurs")
            {
                Thurs.Click();
            }

            //StartTime and End time for monday
            ThrusStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            ThrusEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //Click on Remove the Skill-Exchangetag
            RemoveSkillExchageTag.Click();

            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);
            //WorkSample Upload
            //WorkSample.Click();
            //AutoItX3 autoIt = new AutoItX3();
            //autoIt.WinActivate("Open");
            //Thread.Sleep(1000);
            //autoIt.Send(Base.FilePath);
            //Thread.Sleep(2000);
            //autoIt.Send("{ENTER}");
            //Thread.Sleep(1000);
            Save.Click();


        }
        //internal void EditShareSkill()
        //{

        //}
    }
}
