## Console App Enhancements

After work on the [Master](https://github.com/Chris-Filiatrault/veritec-coding-assignment) branch was submitted, I received feedback as to how I could improve the solution.

This branch contains additional commits with the implementation of these suggestions.

**Suggestions included:**
  
-[x] Don't use a try/catch block for predictable user-input errors <br>
  
-[x] Reduce comments
  
-[x] Create unit tests

-[x] Split code into classes
    - improves extensibility
    - improves readability
    - easier to unit test
    
**My own additions:** 

-[x] Add documentation

-[x] Handle $ symbol in user input if present

-[ ] Convert to currency
  

**More work is required with regards to:**
- Accessibility of properties/methods
- Only make methods/properties public when needed
- Use constants if not mutating the value 
- More elegantly handle default value for payFrequency in UserInput.cs (defaults to 12)
- Generalise methods in UserInput so they aren't console application specific
