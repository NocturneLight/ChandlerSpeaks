class fooclass:
    name = "Antonio"

    age = None

    def f(self):
        return self.name
    
    def getAge(self):
        return self.age

fooTest = fooclass()

fooTest.name = "Joe Bob Briggs"

fooTest.age = 56

def bar():
    return fooTest.f();