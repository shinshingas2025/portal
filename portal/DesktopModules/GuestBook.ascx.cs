namespace Rainbow.DesktopModules.GuestBook
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using System.Xml;
	using Rainbow.UI;
	using Rainbow.UI.WebControls;
	using Rainbow.UI.DataTypes;
	using Rainbow.Configuration;
	using Esperantus;
	using Rainbow.Design;
	using System.IO;


	/// <summary>
	///		Summary description for ECards.
	/// </summary>
	public class GuestBook :  PortalModuleControl 
	{
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.DropDownList drpCountryField;
		protected System.Web.UI.WebControls.TextBox txtComment;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.DropDownList drpGender;
		protected Rainbow.UI.WebControls.Paging pgRecords;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button1;
		
		protected System.Web.UI.WebControls.DataList myDataList;
		
		/// <summary>
		/// Resize Options
		/// NoResize : Do not resize the picture
		/// FixedWidthHeight : Use the width and height specified. 
		/// MaintainAspectWidth : Use the specified height and calculate height using the original aspect ratio
		/// MaintainAspectHeight : Use the specified width and calculate width using the original aspect ration
		/// </summary>

		private void Page_Load(object sender, System.EventArgs e) 
		{
			
			// Obtain ECard information from ECards table
			// and bind to the datalist control
			myDataList.RepeatDirection=RepeatDirection.Vertical ; 
			myDataList.RepeatColumns =  1;

			
			
			BindCountry();
			pgRecords.CausesValidation = false;
			pgRecords.RecordsPerPage = Int32.Parse(Settings["RecordsPerPage"].ToString());
			BindData(pgRecords.PageNumber);
		}

		private void Page_Changed(object sender, System.EventArgs e)
		{
			BindData(pgRecords.PageNumber);
		}

		private void BindData(int PageNumber)
		{
			GuestBookDB guestbook = new GuestBookDB();

			
			DataSet ds = guestbook.GetGuestBookPaged(ModuleID,PageNumber, Int32.Parse(Settings["RecordsPerPage"].ToString()));

			if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				pgRecords.RecordCount = (int)(ds.Tables[0].Rows[0]["RecordCount"]);
			}

			//myDataList.BorderWidth=Unit.Pixel(1);
			// DataBind ECards to DataList Control
				
			//End Indah Fuldner
			// DataBind ECards to DataList Control
			myDataList.DataSource =ds;
			myDataList.DataBind();		
		}
		

		/// <summary>
		/// Public constructor. Sets base settings for module.
		/// </summary>
		public GuestBook() 
		{
			//Custom settings
			SettingItem DelayExpire = new SettingItem(new IntegerDataType());
			DelayExpire.Value = "60";
			DelayExpire.MinValue = 0;
			DelayExpire.MaxValue = 3650; //10 years
			DelayExpire.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			DelayExpire.Description ="";
			this._baseSettings.Add("DelayExpire", DelayExpire);

			//Indah Fuldner
			SettingItem RepeatDirection = new SettingItem(new ListDataType("Vertical;Horizontal"));
			RepeatDirection.Required=true;
			RepeatDirection.Value = "Horizontal";
			RepeatDirection.Order=1;	
			RepeatDirection.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			RepeatDirection.Description ="";
			this._baseSettings.Add("RepeatDirectionSetting", RepeatDirection);

			SettingItem RepeatColumn = new SettingItem(new IntegerDataType());
			RepeatColumn.Required=true;
			RepeatColumn.Value = "1";
			RepeatColumn.MinValue=1;
			RepeatColumn.MaxValue=10;
			RepeatColumn.Order=2;
			RepeatColumn.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			RepeatColumn.Description ="";
			this._baseSettings.Add("RepeatColumns", RepeatColumn);

			SettingItem RecordsPerPage = new SettingItem(new IntegerDataType());
			RecordsPerPage.Required=true;
			RecordsPerPage.Value = "10";
			RecordsPerPage.MinValue=5;
			RecordsPerPage.MaxValue=30;
			RecordsPerPage.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			RecordsPerPage.Description ="";
			this._baseSettings.Add("RecordsPerPage", RecordsPerPage);

			SettingItem showItemBorder = new SettingItem(new BooleanDataType());
			showItemBorder.Value="false";        
			showItemBorder.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			showItemBorder.Description ="";
			this._baseSettings.Add("ShowBorder", showItemBorder);

			//Choose your editor here
			SettingItem Editor = new SettingItem(new HtmlEditorDataType());
			Editor.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			Editor.Description ="";
			this._baseSettings.Add("Editor", Editor);

			//Show Upload (Active up editor only)
			SettingItem ShowUpload = new SettingItem(new BooleanDataType());
			ShowUpload.Value = "true";
			ShowUpload.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			ShowUpload.Description ="";
			this._baseSettings.Add("ShowUpload", ShowUpload);
	  
			//Windows height
			SettingItem ControlHeight = new SettingItem(new IntegerDataType());
			ControlHeight.Value = "300";
			ControlHeight.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			ControlHeight.Description ="";
			this._baseSettings.Add("Height", ControlHeight);

			//Windows width
			SettingItem ControlWidth = new SettingItem(new IntegerDataType());
			ControlWidth.Value = "650";
			ControlWidth.Group = SettingItemGroup.MODULE_SPECIAL_SETTINGS;
			ControlWidth.Description ="";
			this._baseSettings.Add("Width", ControlWidth);
			SupportsWorkflow = true;

			
		}

		#region General Implementation
		/// <summary>
		/// GuidID 
		/// </summary>
		public override Guid GuidID 
		{
			get
			{
				return new Guid("{0CCB791D-4E1A-4f2f-866C-EC949EBF1399}");
			}
		}

		#region Search Implementation
		/// <summary>
		/// Searchable module
		/// </summary>
		public override bool Searchable
		{
			get
			{
				return true;
			}
		}
		/// <summary>
		/// Searchable module implementation
		/// </summary>
		/// <param name="portalID">The portal ID</param>
		/// <param name="userID">ID of the user is searching</param>
		/// <param name="searchString">The text to search</param>
		/// <param name="searchField">The fields where perfoming the search</param>
		/// <returns>The SELECT sql to perform a search on the current module</returns>
		public override string SearchSqlSelect(int portalID, int userID, string searchString, string searchField)
		{
			Rainbow.Helpers.SearchDefinition s = new Rainbow.Helpers.SearchDefinition("rb_ECards", "Title", "Title","CreatedByUser", "CreatedDate", searchField);
			return s.SearchSqlSelect(portalID, userID, searchString);
		}
		#endregion
		
		# region Install / Uninstall Implementation
		public override void Install(System.Collections.IDictionary stateSaver)
		{
			string currentScriptName = Server.MapPath(this.TemplateSourceDirectory + "/Install.sql");
			ArrayList errors = Rainbow.Helpers.DBHelper.ExecuteScript(currentScriptName, true);
			if (errors.Count > 0)
			{
				// Call rollback
				throw new Exception("Error occurred inside ECards :" + errors[0].ToString());
			}
		
		}

		public override void Uninstall(System.Collections.IDictionary stateSaver)
		{
			string currentScriptName = Server.MapPath(this.TemplateSourceDirectory + "/Uninstall.sql");
			ArrayList errors = Rainbow.Helpers.DBHelper.ExecuteScript(currentScriptName, true);
			if (errors.Count > 0)
			{
				// Call rollback
				throw new Exception("Error occurred:" + errors[0].ToString());
			}
		
		}

		# endregion


		#endregion


		#region Web Form Designer generated code

		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			//pgRecords = new Paging();
			pgRecords.OnMove += new EventHandler(Page_Changed);
			// Create a new Title the control
			ModuleTitle = new DesktopModuleTitle();
			// Set here title properties
			// Add support for the edit page
			ModuleTitle.AddUrl = "~/DesktopModules/ECards/ECardsEdit.aspx";
			// Add title ad the very beginning of 
			// the control's controls collection
			Controls.AddAt(0, ModuleTitle);
		
			base.OnInit(e);
		}

		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void BindCountry()
		{
			//Country filter limits contry list
			

			
			drpCountryField.DataSource = Esperantus.CountryInfo.GetCountries(Esperantus.CountryTypes.InhabitedCountries,Esperantus.CountryFields.DisplayName);
			drpCountryField.DataBind();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			
				GuestBookDB guestbook = new GuestBookDB();
				if (txtEmail.Text == "") txtEmail.Text = " ";
				guestbook.AddGuestBook(txtName.Text,txtEmail.Text,txtWebSite.Text,drpCountryField.SelectedItem.Text.ToString(),txtComment.Text.Replace("\n","<br>"),drpGender.SelectedValue.ToString (),ModuleID);
				txtName.Text = "";
				txtEmail.Text ="";
				txtWebSite.Text  = "http://";
				txtComment.Text = "";
				this.BindData(pgRecords.PageNumber);
			
		}

		


		/// <summary>
		/// Structure used for list settings
		/// </summary>
		public struct Option
		{
			private int val;
			private string name;
	
			public int Val 
			{
				get { return this.val; }
				set { this.val = value; }
			}
	
			public string Name
			{
				get { return this.name; }
				set { this.name = value; }
			}
	
			public Option(int aVal, string aName)
			{
				val = aVal;
				name = aName;
			}
		}

	}
}
