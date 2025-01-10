# Contributing to PaddleWrapper

👋 First off, thank you for considering contributing to PaddleWrapper! It's people like you that make PaddleWrapper such a great tool.

## Code of Conduct

This project and everyone participating in it is governed by our Code of Conduct. By participating, you are expected to uphold this code.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible:

* Use a clear and descriptive title
* Include stack traces and error messages
* Specify your .NET environment and version
* Include the version of PaddleWrapper you're using
* Provide specific examples to demonstrate the steps
* Describe the exact steps which reproduce the problem
* Explain which behavior you expected to see instead and why
* Describe the behavior you observed after following the steps

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

* List any potential drawbacks
* A clear and descriptive title
* If possible, include code examples
* Explain why this enhancement would be useful
* A detailed description of the proposed functionality

### Pull Requests

1. Fork the repo and create your branch from `main`
2. If you've added code that should be tested, add tests
3. Ensure the test suite passes
4. Make sure your code follows the existing code style
5. Write a good commit message

## Development Process

1. Clone the repository
```bash
git clone https://github.com/yazilimacademy/paddle-wrapper.git
```

2. Create a branch
```bash
git checkout -b feature/my-new-feature
```

3. Make your changes and commit them
```bash
git commit -m "feat: add some feature"
```

4. Push to your fork
```bash
git push origin feature/my-new-feature
```

5. Open a Pull Request

## Coding Style

* Follow C# naming conventions
* Use 4 spaces for indentation
* Use async/await consistently
* Follow the existing code style
* Keep lines under 120 characters
* Use `var` when the type is obvious
* Add XML documentation comments for public APIs

## Commit Messages

We follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

* `fix:` - A bug fix
* `feat:` - A new feature
* `docs:` - Documentation only changes
* `perf:` - A code change that improves performance
* `chore:` - Changes to the build process or auxiliary tools
* `test:` - Adding missing tests or correcting existing tests
* `style:` - Changes that do not affect the meaning of the code
* `refactor:` - A code change that neither fixes a bug nor adds a feature

Example:
```
feat: add support for webhook validation

- Add WebhookValidator class
- Add unit tests for validation
- Implement signature verification
```

## Testing

* Use meaningful test names
* Aim for high test coverage
* Write unit tests for new features
* Follow the Arrange-Act-Assert pattern
* Ensure all tests pass before submitting a PR

## Documentation

* Update the README.md if needed
* Include code examples where appropriate
* Keep documentation up to date with changes
* Add XML documentation comments for public APIs

## Questions?

Feel free to create an issue with the "question" label if you need help or clarification.

## License

By contributing, you agree that your contributions will be licensed under the GPL-3.0 License. 