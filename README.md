# Pure.Diagram.RelationalModel.Abstractions.Serialization.System

`System.Text.Json` converters for diagram relational model abstractions in the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.Diagram.RelationalModel.Abstractions.Serialization.System/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Diagram.RelationalModel.Abstractions.Serialization.System/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Diagram.RelationalModel.Abstractions.Serialization.System/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Diagram.RelationalModel.Abstractions.Serialization.System/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Diagram.RelationalModel.Abstractions.Serialization.System)](https://www.nuget.org/packages/Pure.Diagram.RelationalModel.Abstractions.Serialization.System)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Diagram.RelationalModel.Abstractions.Serialization.System` provides `System.Text.Json` converters that serialize and deserialize the diagram relational model interfaces defined in [`Pure.Diagram.RelationalModel.Abstractions`](https://github.com/kudima03/Pure.Diagram.RelationalModel.Abstractions). Each interface maps to a custom `JsonConverter<T>` backed by an internal sealed record for round-trip fidelity.

## Converters

| Class | Converts |
|---|---|
| `DiagramRelationalModelConverter` | `IDiagramRelationalModel` |
| `DiagramSeriesRelationalModelConverter` | `IDiagramSeriesRelationalModel` |
| `DiagramTypeRelationalModelConverter` | `IDiagramTypeRelationalModel` |
| `DiagramRelationalModelAbstractionsConverters` | `IEnumerable<JsonConverter>` containing all three converters above |

## Design Principles

- **Interface-preserving** — converters target abstract interfaces, so any implementation serializes transparently.
- **Internal DTOs** — each converter delegates to a private sealed record with `[JsonConstructor]`; no internal types leak into the public API.

## Dependencies

- [`Pure.Diagram.RelationalModel.Abstractions`](https://github.com/kudima03/Pure.Diagram.RelationalModel.Abstractions) — diagram relational model interfaces
