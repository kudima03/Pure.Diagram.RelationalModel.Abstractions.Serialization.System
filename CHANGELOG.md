# Changelog

All notable changes to Pure.Diagram.RelationalModel.Abstractions.Serialization.System are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.0.1.0] — 2026-04-23

### Added

- **`DiagramTypeRelationalModelConverter`** — `System.Text.Json` converter
  for `IDiagramTypeRelationalModel`.
- **`DiagramSeriesRelationalModelConverter`** — `System.Text.Json` converter
  for `IDiagramSeriesRelationalModel`.
- **`DiagramRelationalModelConverter`** — `System.Text.Json` converter for
  `IDiagramRelationalModel`.
- **`DiagramRelationalModelAbstractionsConverters`** — an
  `IEnumerable<JsonConverter>` bundling all three converters above for
  convenient registration with `JsonSerializerOptions.Converters`.
