using System;
using System.Drawing;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;

namespace BusinessUnitHierarchy
{
    public partial class BusinessUnitHierarchyControl : PluginControlBase
    {
        private Settings _mySettings;

        public BusinessUnitHierarchyControl()
        {
            InitializeComponent();
        }

        private void BusinessUnitHierarchyControl_Load(object sender, EventArgs e)
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out _mySettings))
            {
                _mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void PopulateBusinessUnits()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Populating Business units",
                Work = (worker, args) =>
                {
                    LogInfo("Parent business unit retrival started");
                    var getBusinessUnits = new QueryExpression("businessunit");
                    getBusinessUnits.ColumnSet.AddColumns("name", "parentbusinessunitid", "businessunitid", "isdisabled");
                    getBusinessUnits.Criteria.AddCondition(new ConditionExpression("parentbusinessunitid", ConditionOperator.Null));
                    args.Result = Service.RetrieveMultiple(getBusinessUnits);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (args.Result != null)
                    {
                        ClearControls();
                        PopulateParentNodes((EntityCollection)args.Result);
                        ColorInactiveNodes(tvBusinessUnits.Nodes);
                        tvBusinessUnits.ExpandAll();
                    }
                }
            });
        }

        private void ClearControls()
        {
            LogInfo("Clear controls");
            tvBusinessUnits.Nodes.Clear();
            lvUsers.Items.Clear();
            lvTeams.Items.Clear();
        }

        private void PopulateParentNodes(EntityCollection businessUnits)
        {
            LogInfo("Populate parent business unit");
            foreach (Entity businessUnit in businessUnits.Entities)
            {
                string isDisabled = businessUnit.GetAttributeValue<bool>("isdisabled") ? "Inactive" : "Active";
                string businessUnitId = businessUnit.GetAttributeValue<Guid>("businessunitid").ToString() + "|" + isDisabled;
                string businessUnitName = businessUnit.GetAttributeValue<string>("name");
                TreeNode parentNode = tvBusinessUnits.Nodes.Add(businessUnitId, businessUnitName);
                PopulateChildNodes(businessUnit.GetAttributeValue<Guid>("businessunitid").ToString(), parentNode);
            }
        }

        private void PopulateChildNodes(string parentId, TreeNode parentNode)
        {
            LogInfo("Populating child business units for " + parentNode.Text + "business unit");
            var getChildBusinessUnits = new QueryExpression("businessunit");
            getChildBusinessUnits.ColumnSet.AddColumns("name", "parentbusinessunitid", "businessunitid", "isdisabled");
            getChildBusinessUnits.Criteria.AddCondition(new ConditionExpression("parentbusinessunitid", ConditionOperator.Equal, Guid.Parse(parentId)));
            var childBusinessUnits = Service.RetrieveMultiple(getChildBusinessUnits);
            TreeNode childNode;
            foreach (Entity childBusinessUnit in childBusinessUnits.Entities)
            {
                string isDisabled = childBusinessUnit.GetAttributeValue<bool>("isdisabled") ? "Inactive" : "Active";
                string businessUnitId = childBusinessUnit.GetAttributeValue<Guid>("businessunitid").ToString() + "|" + isDisabled;
                string businessUnitName = childBusinessUnit.GetAttributeValue<string>("name");
                if (childBusinessUnit.GetAttributeValue<EntityReference>("parentbusinessunitid") == null)
                {
                    childNode = tvBusinessUnits.Nodes.Add(businessUnitId, businessUnitName);
                }
                else
                {
                    childNode = parentNode.Nodes.Add(businessUnitId, businessUnitName);
                    PopulateChildNodes(childBusinessUnit.GetAttributeValue<Guid>("businessunitid").ToString(), childNode);
                }
            }
        }

        private void ColorInactiveNodes(TreeNodeCollection nodeCollection)
        {
            LogInfo("Coloring inactive business units");
            foreach (TreeNode treeNode in nodeCollection)
            {
                string isDisabled = treeNode.Name.Split('|')[1];
                if (isDisabled == "Inactive")
                {
                    treeNode.ForeColor = Color.Red;
                }
                ColorInactiveNodes(treeNode.Nodes);
            }
        }
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BusinessUnitHierarchyControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), _mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (_mySettings != null && detail != null)
            {
                _mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void btnGenerateBU_Click(object sender, EventArgs e)
        {
            ExecuteMethod(PopulateBusinessUnits);
        }

        private void tvBusinessUnits_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ExecuteMethod(LoadUsers);
            ExecuteMethod(LoadTeams);
        }

        private void LoadUsers()
        {
            var businessUnitId = tvBusinessUnits.SelectedNode.Name.Split('|')[0];
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Users",
                Work = (worker, args) =>
                {
                    var getUsers = new QueryExpression("systemuser");
                    getUsers.ColumnSet.AddColumns("fullname", "internalemailaddress");
                    getUsers.Criteria.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, businessUnitId));
                    args.Result = Service.RetrieveMultiple(getUsers);
                },
                PostWorkCallBack = (args) =>
                {
                    lvUsers.Items.Clear();
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (args.Result != null)
                    {
                        lblUsers.Text = "Users in " + tvBusinessUnits.SelectedNode.Text + " Business Unit";
                        foreach (var userData in (args.Result as EntityCollection).Entities)
                        {
                            ListViewItem listViewItem = new ListViewItem(userData.GetAttributeValue<string>("fullname"));
                            listViewItem.SubItems.Add(userData.GetAttributeValue<string>("internalemailaddress"));
                            lvUsers.Items.Add(listViewItem);
                        }
                    }
                }
            });
        }

        private void LoadTeams()
        {
            var businessUnitId = tvBusinessUnits.SelectedNode.Name.Split('|')[0];
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Teams",
                Work = (worker, args) =>
                {
                    var getTeams = new QueryExpression("team");
                    getTeams.ColumnSet.AddColumns("name", "teamtype", "administratorid");
                    getTeams.Criteria.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, businessUnitId));
                    args.Result = Service.RetrieveMultiple(getTeams);
                },
                PostWorkCallBack = (args) =>
                {
                    lvTeams.Items.Clear();
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (args.Result != null)
                    {
                        lblTeams.Text = "Teams in " + tvBusinessUnits.SelectedNode.Text + " Business Unit";
                        foreach (var teamData in (args.Result as EntityCollection).Entities)
                        {
                            ListViewItem listViewItem = new ListViewItem(teamData.GetAttributeValue<string>("name"));
                            listViewItem.SubItems.Add(teamData.FormattedValues["teamtype"]);
                            listViewItem.SubItems.Add(teamData.GetAttributeValue<EntityReference>("administratorid").Name);
                            lvTeams.Items.Add(listViewItem);
                        }
                    }
                }
            });
        }
    }
}