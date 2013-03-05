describe "given the root node of a tree" do
  context "when counting the nodes of a tree with one node" do
    before :all do
      @root = Node.new

      @counts = count_nodes(@root)
    end

    it "counts 1 at level 1" do
      expect(@counts[0]).to eq(1)
    end
  end

  context "when counting the nodes of a tree with two nodes" do
    before :all do
      @root = Node.new
      @root.left = Node.new

      @counts = count_nodes(@root)
    end

    {
     1 => 1,
     2 => 1
    }.each_pair do |level, count|
      it "counts #{count} at level #{level}" do
        expect(@counts[level - 1]).to eq(count)
      end
    end
  end

  context "when counting the nodes of a binary tree with two levels" do
    before :all do
      @root = Node.new
      @root.left = Node.new
      @root.right = Node.new

      @counts = count_nodes(@root)
    end

    {
     1 => 1,
     2 => 2
    }.each_pair do |level, count|
      it "counts #{count} at level #{level}" do
        expect(@counts[level - 1]).to eq(count)
      end
    end
  end

  context "when counting the nodes of a binary tree with two levels" do
    before :all do
      @root = Node.new
      @root.left = Node.new
      @root.right = Node.new
      @root.left.left = Node.new
      @root.left.right = Node.new
      @root.right.left = Node.new
      @root.left.left.left = Node.new
      @counts = count_nodes(@root)
    end

    {
     1 => 1,
     2 => 2,
     3 => 3,
     4 => 1
    }.each_pair do |level, count|
      it "counts #{count} at level #{level}" do
        expect(@counts[level - 1]).to eq(count)
      end
    end
  end
end

def count_nodes(node)
  level_counts = []
  tally(node, 0, level_counts)
  level_counts
end

def tally(node, level, counts)
  return if node.nil?

  counts[level] = 0 if(counts[level].nil?)

  counts[level] += 1
  tally(node.left, level + 1, counts)
  tally(node.right, level + 1, counts)
end

class Node
  attr_accessor :left, :right, :data
end
