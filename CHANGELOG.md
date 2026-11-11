# Changelog

All notable changes to Pure.Diagram.RelationalModel.Abstractions.Serialization.System are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.0.2.0] — 2026-11-11

### Added

- **.NET 11 support** — the package now also targets `net11.0`
  (existing target frameworks are kept).

### Changed

- Updated `Pure.Diagram.RelationalModel.Abstractions` to
  `0.1.0-preview.2.1.0`.
- The README is now packed into the NuGet package.
- Assembly and file versions are now derived from the release tag.

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
