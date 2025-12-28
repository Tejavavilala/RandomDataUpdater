# RandomDataUpdater (XrmToolBox Plugin)

**RandomDataUpdater** is a comprehensive remediation tool for Dynamics 365/Dataverse developers. It scans for "half-baked" or incomplete records and populates them with valid, type-safe data to ensure robust testing environments.

Unlike simple scripts that only handle text, **RandomDataUpdater supports nearly all Dataverse data types**, allowing you to fill complex entities with rich, valid data in a single click.

## 🎯 The Problem: "Half-Baked" Data
Test environments are often filled with records that are technically created but missing 80% of their data.
* *Result:* Dashboards look empty, workflows don't trigger, and plugins fail because fields like `Budget Amount` or `Customer Type` are null.

## ✅ The Solution: Comprehensive Data Injection
This tool intelligently fills gaps while respecting the specific data type of every column:

### 🛡️ Supported Data Types
* **📝 Text & Memos:** Generates realistic strings (names, emails, descriptions) respecting max length.
* **🔗 Lookups & Customer:** Automatically resolves relationships by linking to existing valid records (maintains referential integrity).
* **🔢 Numbers & Currency:** Generates valid Integers, Decimals, and Money values within realistic ranges.
* **📅 DateTime:** Populates valid dates (Past/Future logic available).
* **✅ OptionSets (Choices):** Selects only valid integer values defined in your metadata.
* **☑️ Booleans:** Randomizes True/False values.

## 🚀 Key Features
* **Bulk Remediation:** Fix thousands of records in minutes.
* **Schema Awareness:** Automatically detects the data type of every empty field and applies the correct generation logic.
* **Validation Ready:** Data formats (Email, Phone) are respected so records pass CRM business rules.
* **XrmToolBox Native:** Seamless integration with your existing workflow.

## 🛠 Tech Stack
* **Language:** C# / .NET
* **Platform:** XrmToolBox
* **SDK:** Microsoft Dataverse SDK

## 🚧 Status
* **Current Version:** V1 (MVP) - Operational.
* **Roadmap:** Adding support for complex Virtual Fields and File/Image data types.