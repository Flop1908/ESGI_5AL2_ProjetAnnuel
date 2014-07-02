//
//  AnneProductViewCell.m
//  Anne&DocTique2
//
//  Created by Kapi on 28/05/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AnneProductViewCell.h"
#import "AnneProduct.h"

@interface AnneProductViewCell ()
//@property (strong, nonatomic) IBOutlet UILabel *titleLabel;
//@property (strong, nonatomic) IBOutlet UILabel *detailsLabel;
@property (strong, nonatomic) IBOutlet UILabel *dateLabel;
@property (strong, nonatomic) IBOutlet UILabel *textView;
@property (strong, nonatomic) IBOutlet UILabel *author;
//@property (strong, nonatomic) IBOutlet UIImageView *iconView;
@end


@implementation AnneProductViewCell


- (void)awakeFromNib {
    [super awakeFromNib];
    
    self.backgroundColor = [UIColor whiteColor];
    
    UIView* selectedBGView = [[UIView alloc] initWithFrame:self.bounds];
    selectedBGView.backgroundColor = self.tintColor;
    self.selectedBackgroundView = selectedBGView;
    
    
}

- (void)setProduct:(AnneProduct *)product {
    if (![product isEqual:_product]) {
        _product = product;
        self.textView.text = _product.description;
        self.author.text = _product.author;
        //self.dateLabel.text = _product.date;
        
    }
}
/*
+(void)configureWithText:(AnneProduct*)product{
    [self setProduct : product];
    [cell configureWithText:[NSString stringWithFormat:@"Author %zd", indexPath.row]];
    [self author = product.author];
    [self date = product.date];
}*/

 -(IBAction) vote:(UIButton *) sender {
 NSLog(@"You");
/*if ((sender == youDeservedIt && entry.deserveVoted) || (sender == yourLifeSucks && entry.agreeVoted)) {
 [UIView animateWithDuration:0.4 animations:^{
 sender.alpha = 0;
 } completion:^(BOOL finished) {
 [sender setTitle:@"You have already voted" forState:UIControlStateNormal];
 
 [UIView animateWithDuration:0.4 animations:^{
 sender.alpha = 1;
 } completion:^(BOOL finished) {
 [UIView animateWithDuration:0.4 delay:2 options:0 animations:^{
 sender.alpha = 0;
 } completion:^(BOOL finished) {
 [self setDeserveCount:AnneProductViewCell.deserveCount];
 [self setLifeSucksCount:entry.agreeCount];
 
 [UIView animateWithDuration:0.4 animations:^{
 sender.alpha = 1;
 }];
 }];
 }];
 }];
 }
 else {
 [UIView animateWithDuration:0.4 animations:^{
 sender.alpha = 0;
 } completion:^(BOOL finished) {
 if (sender == youDeservedIt) {
 product.deserveCount++;
 product.deserveVoted = YES;
 [self setDeserveCount:entry.deserveCount];
 [self registerVote:@"deserved"];
 }
 else {
 entry.agreeCount++;
 entry.agreeVoted = YES;
 [self setLifeSucksCount:entry.agreeCount];
 [self registerVote:@"agree"];
 }
 
 [UIView animateWithDuration:0.4 animations:^{
 sender.alpha = 1;
 }];
 }];
 }*/
 }
 
 -(void) setDeserveCount:(int) count {
     //[youDeservedIt setTitle:[NSString stringWithFormat:@"you deserved(%d)", count] forState:UIControlStateNormal];
 }
 
 -(void) setLifeSucksCount:(int) count {
 //[yourLifeSucks setTitle:[NSString stringWithFormat:@"your life sucks (%d)", count] forState:UIControlStateNormal];
 }
 

@end;
