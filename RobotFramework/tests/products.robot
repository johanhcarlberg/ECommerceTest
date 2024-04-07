*** Settings ***
Documentation    Test suite for testing products page
Metadata    Version    0.1
Metadata    User story link    https://dev.azure.com/johanhcarlberg/ECommerceTest/_workitems/edit/10
Metadata    User story id    10
Metadata    User story name    As a customer I want to be able to list all products so that I can select a product to buy
Library    SeleniumLibrary
*** Variables ***
${API_URL}    http://localhost:8889
${BROWSER}    chrome

*** Test Cases ***
Products page should list products
    [Documentation]    Test case for listing all products
    Given User has opened web browser
    When User goes to Products page
    Then Page should display products


*** Keywords ***
Open browser and maximize
    [Documentation]    Keyword for opening browser and maximizing
    ...    used for suite setup
    Open Browser    browser=${BROWSER}
    Log To Console    ${API_URL}
    Log To Console    ${BROWSER}
    Maximize Browser Window
    Set Selenium Speed    0.1

User has opened web browser
    Open browser and maximize

User goes to Products page
    Go To    ${API_URL}/products

Page should display products
    Wait Until Page Contains    Test Product 1
    