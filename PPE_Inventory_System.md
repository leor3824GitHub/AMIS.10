# PPE Inventory System

## COA-Compliant Domain Design (NFA Philippines)

------------------------------------------------------------------------

## Overview

This PPE Inventory System is designed to:

-   Track lifecycle of each PPE asset
-   Maintain full audit trail
-   Support COA-required documents:
    -   PPERR -- Receipt of PPE
    -   PAR -- Property Acknowledgment Receipt
    -   RRP -- Return Receipt of Property
    -   PPEIR -- Issuance / Transfer / Sale / Disposal
-   Preserve custodian accountability
-   Enable reconciliation by Property Number

The **PhysicalAsset** is the Aggregate Root of the system.

------------------------------------------------------------------------

# Core Entities

## 1. PhysicalAsset (Aggregate Root)

Represents one unique PPE item.

Fields: - Id (PK) - PropertyNumber (Unique) - Description - Category -
AcquisitionDate - AcquisitionCost - UsefulLife - ResidualValue -
Condition - Status (Active, Issued, Disposed, Sold) - CurrentCustodianId
(FK) - CurrentLocationId (FK) - PPERRId (FK)

------------------------------------------------------------------------

## 2. AssetTransaction (Audit Trail)

Tracks complete asset movement history.

Fields: - Id (PK) - PhysicalAssetId (FK) - TransactionType (Receipt,
Issue, Return, Transfer, Sale, Disposal) - ReferenceNo -
FromCustodianId - ToCustodianId - FromLocationId - ToLocationId -
TransactionDate - Remarks

------------------------------------------------------------------------

# Document Aggregates

## 3. PPERR (Receipt of PPE)

Fields: - Id (PK) - ReferenceNo - SupplierId (FK) - ReceiptDate -
ReceivedBy

### PPERRItem

-   Id (PK)
-   PPERRId (FK)
-   Description
-   Quantity
-   UnitCost

------------------------------------------------------------------------

## 4. PAR (Property Acknowledgment Receipt)

Fields: - Id (PK) - ReferenceNo - AccountableOfficerId (FK) -
IssueDate - IssuedBy

### PARItem

-   Id (PK)
-   PARId (FK)
-   PhysicalAssetId (FK)
-   ConditionAtIssue

------------------------------------------------------------------------

## 5. RRP (Return Receipt of Property)

Fields: - Id (PK) - ReferenceNo - ReturnedBy (FK) - ReceivedBy (FK) -
ReturnDate

### RRPItem

-   Id (PK)
-   RRPId (FK)
-   PhysicalAssetId (FK)
-   ConditionAtReturn

------------------------------------------------------------------------

## 6. PPEIR (Transfer / Sale / Disposal)

Fields: - Id (PK) - ReferenceNo - TransactionType (Transfer, Sale,
Disposal) - Date - ApprovedBy

### PPEIRItem

-   Id (PK)
-   PPEIRId (FK)
-   PhysicalAssetId (FK)
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

Supplier → PPERR → PhysicalAsset (Created) → PAR (Issued) → RRP
(Returned) → PPEIR (Transfer / Sale / Disposal) → AssetTransaction (Full
History)

------------------------------------------------------------------------

# Design Principles

-   PhysicalAsset is the Aggregate Root
-   Documents are transactional aggregates
-   AssetTransaction provides complete audit history
-   Reconciliation anchored on PropertyNumber
-   Supports COA reporting requirements
