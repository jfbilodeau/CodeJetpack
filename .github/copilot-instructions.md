# CodeJetpack — Copilot Instructions

This file records repository-level preferences, style choices, and structural notes for GitHub Copilot and contributors.

Purpose
-------

- This repository is a GitHub Copilot demo project.
- It is a minimal console application with business logic contained in a shared class library so it can later be reused by a web UI.

Project preferences and conventions
-----------------------------------

- Project name: CodeJetPack
- Target framework: .NET 9.0 (net9.0)
- Use modern .NET coding patterns (top-level statements, implicit usings, nullable enabled by default).
- Prefer Microsoft-authored NuGet libraries before introducing third-party packages.
- Application type: Console app (for now). Business logic must live in a separate class library for reuse.
- Business library project: `CodeJetpack.Business`
- Class name prefix: `Jf` (for example: `JfMyService`, `JfOrderManager`). Use the `Jf` prefix for public classes intended as business components.

Repository structure
--------------------

- CodeJetpack/ - console application project
  - CodeJetpack.csproj
  - Program.cs
  - preferences.json
  - copilot-instructions.md
- CodeJetpack.Business/ - shared business logic class library
  - CodeJetpack.Business.csproj
  - Jf*.cs (business classes)

Preferences storage
-------------------

- Basic preferences are stored in `CodeJetpack/preferences.json` so tools and Copilot can quickly read project-level metadata such as the target framework, project type, and naming conventions.

Coding style and guidance for Copilot
-----------------------------------

- Favor small, well-named methods and classes.
- Prefer dependency injection-friendly designs (add interfaces like `IJfMyService` when multiple implementations or testing is needed).
- Keep business logic in `CodeJetpack.Business`. The console app should orchestrate only I/O and wiring.
- When adding dependencies, choose Microsoft packages first (for example: `Microsoft.Extensions.*` packages for logging, configuration, DI).
- Add unit tests to a test project (e.g., `CodeJetpack.Tests`) using xUnit or MSTest when adding real logic.

Notes for contributors
----------------------

- This is a demo repository focusing on Copilot-assisted development. Keep changes clear and well-documented so Copilot examples remain easy to follow.
- If you change the class prefix or other conventions, update `preferences.json` and this file.

Contact
-------

Repository maintainer: (local project)
