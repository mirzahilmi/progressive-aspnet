.PHONY: test
test:
	@hurl --test test/*.hurl

.PHONY: hit
hit:
	@hurl test/*.hurl
