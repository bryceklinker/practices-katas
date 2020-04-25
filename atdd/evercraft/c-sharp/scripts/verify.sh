#!/usr/bin/env bash

ACCEPTANCE_TESTS_DIRECTORY="./tests/Evercraft.Features"

install_dependencies() {
    npm install -g yarn
    dotnet restore
    
    pushd ${ACCEPTANCE_TESTS_DIRECTORY}
        yarn install    
    popd
}

run_unit_tests() {
    dotnet test
}

run_acceptance_tests() {
    pushd ${ACCEPTANCE_TESTS_DIRECTORY}
        yarn test
    popd
}

main() {
    install_dependencies
    run_unit_tests
    run_acceptance_tests
}

main