# Semi-Expendable Property Inventory System

## COA-Compliant Domain Design (Philippine Government)

------------------------------------------------------------------------

## Overview

This Semi-Expendable Property Inventory System is designed to:

-   Track semi-expendable items (below PPE capitalization threshold)
-   Maintain accountability using ICS (Inventory Custodian Slip)
-   Track issuance, return, transfer, and disposal
-   Maintain full audit trail
-   Support COA reporting requirements

Unlike PPE, semi-expendable items are monitored primarily through
custodial accountability, not depreciation tracking.

The SemiExpendableAsset is the Aggregate Root.

------------------------------------------------------------------------

# Core Entities

## 1. SemiExpendableAsset (Aggregate Root)

Represents one accountable semi-expendable item.

Fields: - Id (PK) - PropertyNumber / ICSNumber - Description -
Category - AcquisitionDate - AcquisitionCost - Condition - Status
(Active, Issued, Returned, Disposed) - CurrentCustodianId (FK) -
CurrentLocationId (FK) - ReceiptReferenceId (FK)

------------------------------------------------------------------------

## 2. AssetTransaction (Audit Trail)

Tracks complete movement history.

Fields: - Id (PK) - SemiExpendableAssetId (FK) - TransactionType
(Receipt, Issue, Return, Transfer, Disposal) - ReferenceNo -
FromCustodianId - ToCustodianId - FromLocationId - ToLocationId -
TransactionDate - Remarks

------------------------------------------------------------------------

# Document Aggregates

## 3. Receipt Document (RIS / DR / Purchase Receipt)

Fields: - Id (PK) - ReferenceNo - SupplierId (FK) - ReceiptDate -
ReceivedBy

### ReceiptItem

-   Id (PK)
-   ReceiptId (FK)
-   Description
-   Quantity
-   UnitCost

------------------------------------------------------------------------

## 4. ICS (Inventory Custodian Slip)

Fields: - Id (PK) - ReferenceNo - AccountableOfficerId (FK) -
IssueDate - IssuedBy

### ICSItem

-   Id (PK)
-   ICSId (FK)
-   SemiExpendableAssetId (FK)
-   ConditionAtIssue

------------------------------------------------------------------------

## 5. Return Document

Fields: - Id (PK) - ReferenceNo - ReturnedBy (FK) - ReceivedBy (FK) -
ReturnDate

### ReturnItem

-   Id (PK)
-   ReturnId (FK)
-   SemiExpendableAssetId (FK)
-   ConditionAtReturn

------------------------------------------------------------------------

## 6. Transfer / Disposal Document

Fields: - Id (PK) - ReferenceNo - TransactionType (Transfer, Disposal) -
Date - ApprovedBy

### TransferItem

-   Id (PK)
-   TransferId (FK)
-   SemiExpendableAssetId (FK)
-   Remarks

------------------------------------------------------------------------

# Supporting Entities

## Employee

-   Id (PK)
-   Name
-   Position
-   OfficeId (FK)

## Office

-   Id (PK)
-   Name
-   Location

## Supplier

-   Id (PK)
-   Name
-   Address
-   TIN

------------------------------------------------------------------------

# Asset Lifecycle Flow

Supplier → Receipt → SemiExpendableAsset (Created) → ICS (Issued to
Custodian) → Return (If applicable) → Transfer / Disposal →
AssetTransaction (Full History)

------------------------------------------------------------------------

# Design Principles

-   SemiExpendableAsset is the Aggregate Root
-   Accountability-centered tracking (ICS-based)
-   No depreciation tracking required
-   Full movement history via AssetTransaction
-   Reconciliation anchored on PropertyNumber / ICSNumber
-   Supports COA reporting (Report on the Physical Count of
    Semi-Expendable Property)
