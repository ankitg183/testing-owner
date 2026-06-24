# Agent Workflow

## Roles
- **Tech Lead**: @ankitg183 — defines and approves features
- **Developer**: GitHub Copilot — implements features following this workflow

---

## Technology Stack

- **Programming Language**: C#

### Build, Compile & Test Instructions

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run tests
dotnet test
```

> All commands should be run from the repository root (or the relevant project directory containing the `.csproj` / `.sln` file).

### Git Ignore

Always ensure a `.gitignore` is present to exclude build artifacts before committing. At minimum it should include:

```
bin/
obj/
.vs/
TestResults/
```

---

## Feature Implementation Workflow

Work through features one at a time, following each step in order **for every feature**. Do not start the next feature until the current one has completed all steps and tests are passing.

---

### Step 1 — Requirements Gathering

- Restate the feature requirements as understood
- Ask clarifying questions covering:
  - Input/output formats
  - Edge cases and error handling
  - Acceptance criteria
  - Dependencies on other features or systems
- Make **no assumptions** — clarify everything explicitly
- Capture all gathered requirements in `requirements.md`

---

### Step 2 — Requirements Review

- Present `requirements.md` to the tech lead for review
- Wait for explicit approval before proceeding
- Incorporate any feedback and re-request approval if changes are significant

---

### Step 3 — Test Cases

- Write test cases **before** any implementation
- Each test case must reference the requirement(s) it validates
- Cover happy paths, edge cases, and error conditions

---

### Step 4 — Test Coverage Review

- Walk through all test cases and explain how each requirement is covered
- Confirm no requirements are left untested

---

### Step 5 — Design Discussion

- Describe the proposed implementation design (architecture, data flow, interfaces)
- Discuss trade-offs and alternatives where relevant
- Wait for tech lead approval or feedback before writing any code
- Incorporate feedback and re-confirm if the design changes materially

---

### Step 6 — Implementation

- Implement the feature according to the approved design
- Run the test suite and verify all test cases pass

---

### Step 7 — Test Failure Resolution

- If any tests fail, do **not** silently fix them
- Explain why each test failed and what the root cause is
- Propose a fix and discuss before applying it

---

## Per-Feature Checklist

Use this checklist for every feature before marking it complete:

- [ ] Requirements restated and clarifying questions asked
- [ ] No assumptions made — all ambiguities resolved
- [ ] `requirements.md` written and up to date
- [ ] Tech lead has reviewed and approved `requirements.md`
- [ ] Test cases written and linked to requirements
- [ ] Test coverage reviewed and all requirements accounted for
- [ ] Design described and discussed
- [ ] Tech lead has approved the design
- [ ] Feature implemented according to approved design
- [ ] All tests pass
- [ ] Any test failures discussed and resolved with tech lead
