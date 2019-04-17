class Node:

	def __init__(self, key, value, nextNode):
		self.key = key
		self.value = value
		self.next = nextNode

class Dictionary:

	def __init__(self):
		self.start = Node(None, None, None)
		self.end = self.start

	def add(self, dictNode):
		pt = self.start
		while pt != self.end or dictNode.value <= pt.value:
			pt = pt.next
		dictNode.next = pt.next
		pt.next = dictNode

a = Dictionary()
b = Node('ce', 'hui', None)

print(b)

a.add()

print(a)

input()

