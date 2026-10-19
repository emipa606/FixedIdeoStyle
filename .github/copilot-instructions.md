# GitHub Copilot Instructions for Fixed Ideo Style (Continued) Mod

Welcome to the Fixed Ideo Style (Continued) mod for RimWorld. This guide aims to facilitate code contributions using GitHub Copilot by providing an overview of the mod, its core features, coding conventions, as well as instructions on XML integration and Harmony patching.

## Mod Overview and Purpose

**Fixed Ideo Style (Continued)** is a mod that enhances RimWorld's building system by maintaining the consistency of ideologically defined building styles. Inspired by the original mod by Ben Lubar, this continuation prevents pawns from constructing buildings of a different style than what was initially placed by the player. Additionally, it offers the functionality to change the style of existing blueprints or frames.

## Key Features and Systems

- **Style Consistency Control:** Ensures that the ideologically correct style is maintained for all constructed buildings.
- **Blueprint and Frame Style Customization:** Provides players with gizmos to alter the style of blueprints and frames before construction.
- **Integration with RimWorld Ideology Expansion:** This mod leverages new ideological styles introduced by the RimWorld Ideology expansion.
- **Seamless Compatibility:** Designed to work with the required Harmony and Ideology dependencies.

## Coding Patterns and Conventions

This mod employs a clean and consistent C# coding style to ensure readability and maintainability:

- **Namespace Organization:** All source files reside within a dedicated namespace related to the mod.
- **Consistent Naming:** CamelCase is used for methods and properties, while PascalCase is used for class and type names.
- **Methodology:** Methods are designed to perform single, clear functions with a strong emphasis on maintaining the mod's core features.

## XML Integration

The mod makes use of XML primarily for metadata and configuration:

- **About.xml:** This XML file contains essential metadata about the mod such as its name, author, and dependencies. Ensure that any changes here align with the current mod version and dependencies.

## Harmony Patching

Harmony is used extensively in this mod to integrate new functionalities and override base game behaviors without altering the original game code:

- **Postfix Methods:** Implemented in various C# classes to extend or modify game behavior after the base method execution.
  - Examples:
    - `Blueprint_Build_GetGizmos.cs`: Uses a postfix to append custom gizmos.
    - `Frame_GetGizmos.cs`: Modifies gizmos specific to frames.
- Ensure harmony patches target the right methods and respect the game's performance and stability.

## Suggestions for Copilot

To maximize the potential of GitHub Copilot, adhere to these suggestions:

- **Contextual Code Completion:** Use Copilot to suggest code snippets that comply with the established coding patterns, like methods for gizmo creation or style verification.
- **Documentation Aid:** Leverage Copilot to generate XML comments for public functions, enhancing code understanding and maintainability.
- **Refactoring Assistance:** Employ Copilot's refactoring suggestions to improve the efficiency and readability of existing code.

For further support or to report issues, join the Discord channel dedicated to this mod. Always ensure to upload logs if encountering bugs. Collaborate by sharing solutions directly to the GitHub repository when appropriate.

Thank you for contributing to the Fixed Ideo Style (Continued) mod. We appreciate your help in enhancing the RimWorld gaming experience!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

