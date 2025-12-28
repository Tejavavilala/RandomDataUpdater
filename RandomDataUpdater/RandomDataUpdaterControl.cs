using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using XrmToolBox.Extensibility;
using RandomDataUpdater.Services;
using RandomDataUpdater.Models;

namespace RandomDataUpdater
{
    public partial class RandomDataUpdaterControl : PluginControlBase
    {
        public RandomDataUpdaterControl()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                MessageBox.Show("Please connect first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEntity.Text) ||
                string.IsNullOrWhiteSpace(txtFetchXml.Text))
            {
                MessageBox.Show("Entity and FetchXML required.");
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating records...",
                Work = (w, a) =>
                {
                    var service = (IOrganizationService)a.Argument;
                    var meta = MetadataService.GetEntityMetadata(service, txtEntity.Text);
                    var records = FetchXmlService.GetRecords(service, txtFetchXml.Text);

                    var rnd = new Random();
                    int updated = 0;

                    foreach (var record in records)
                    {
                        var update = new Entity(record.LogicalName, record.Id);
                        bool changed = false;

                        foreach (var attr in meta.Attributes)
                        {
                            // 🚫 HARD SAFETY RULES (BulkDataCreator style)
                            if (attr.IsPrimaryId == true ||
                                attr.IsValidForUpdate == false ||
                                attr.AttributeType == AttributeTypeCode.DateTime ||
                                attr.LogicalName == "transactioncurrencyid" ||
                                attr.LogicalName.EndsWith("_base"))
                                continue;

                            // Update only EMPTY fields (v1 behavior)
                            if (record.Contains(attr.LogicalName))
                                continue;

                            MockType mockType;

                            switch (attr.AttributeType)
                            {
                                case AttributeTypeCode.String:
                                case AttributeTypeCode.Memo:
                                    mockType = MockType.String;
                                    break;

                                case AttributeTypeCode.Integer:
                                case AttributeTypeCode.Decimal:
                                case AttributeTypeCode.Double:
                                case AttributeTypeCode.Money:
                                    mockType = MockType.Number;
                                    break;

                                case AttributeTypeCode.Boolean:
                                    mockType = MockType.Boolean;
                                    break;

                                case AttributeTypeCode.Picklist:
                                    mockType = MockType.Picklist;
                                    break;

                                case AttributeTypeCode.Lookup:
                                case AttributeTypeCode.Customer:
                                    mockType = MockType.Lookup;
                                    break;

                                default:
                                    continue;
                            }

                            var value = RandomValueService.Generate(
                                service, attr, mockType, rnd);

                            if (value != null)
                            {
                                update[attr.LogicalName] = value;
                                changed = true;
                            }
                        }

                        if (changed)
                        {
                            UndoService.Store(record);
                            service.Update(update);
                            updated++;
                        }
                    }

                    a.Result = $"Updated {updated} records safely.";
                },
                AsyncArgument = Service,
                PostWorkCallBack = (a) =>
                {
                    if (a.Error != null)
                        MessageBox.Show(a.Error.Message, "Error");
                    else
                        MessageBox.Show(a.Result.ToString(), "Done");
                }
            });
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (Service == null) return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Undoing...",
                Work = (w, a) =>
                {
                    UndoService.Undo(Service);
                    a.Result = "Undo completed.";
                },
                PostWorkCallBack = (a) =>
                    MessageBox.Show(a.Result.ToString())
            });
        }
    }
}
