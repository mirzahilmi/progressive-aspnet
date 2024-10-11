.PHONY: run
run:
	@dotnet run

.PHONY: watch
watch:
	@dotnet watch

.PHONY: test
test:
	@hurl --test test/*.hurl
